using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using AutoMapper;
using docAppSqliteProvider;
using docAppDomain;
using Microsoft.AspNetCore.Mvc.Formatters;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace docAppApi
{
	public class Startup
	{
		private MapperConfiguration _mapperConfiguration { get; set; }

		public Startup(IHostingEnvironment env)
		{
			var builder = new ConfigurationBuilder()
				.SetBasePath(env.ContentRootPath)
				.AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
				.AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
				.AddEnvironmentVariables();
			Configuration = builder.Build();

			_mapperConfiguration = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new AutoMapperProfileConfiguration());
			});
		}

		public IConfigurationRoot Configuration { get; }

		// This method gets called by the runtime. Use this method to add services to the container.
		public void ConfigureServices(IServiceCollection services)
		{
			// Add framework services.
			// Use a SQLite database
			services.AddEntityFrameworkSqlite().AddDbContext<docAppContext>();
			services.AddScoped<IDataAccessProvider, SqliteProvider>();

			//Use PostgreSql
			//services.AddEntityFramework().AddNpgsql().AddDbContext<docAppContext>();
			//services.AddScoped<IDataAccessProvider, docAppDomain.PostgreSqlProvider>();

			services.AddSingleton<IMapper>(sp => _mapperConfiguration.CreateMapper());

			var jsonOutputFormatter = new JsonOutputFormatter
			{
				SerializerSettings =
												  new JsonSerializerSettings
												  {
													  ReferenceLoopHandling =
															  ReferenceLoopHandling.Ignore,
													  ContractResolver = new CamelCasePropertyNamesContractResolver()
												  }
			};
			services.AddCors();
			services.AddMvc(
				options =>
				{
					options.OutputFormatters.Clear();
					options.OutputFormatters.Insert(0, jsonOutputFormatter);
				});
		}

		// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
		public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
		{
			loggerFactory.AddConsole(Configuration.GetSection("Logging"));
			loggerFactory.AddDebug();

			app.UseMvc();
		}
	}
}