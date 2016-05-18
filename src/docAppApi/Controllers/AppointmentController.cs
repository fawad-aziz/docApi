using AutoMapper;
using docAppApi.ViewModels;
using docAppDomain;
using docAppDomain.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace docAppApi.Controllers
{
	[Route("api/[controller]")]
	public class AppointmentController
    {
		private readonly IDataAccessProvider _provider;
		private readonly IMapper _mapper;

		public AppointmentController(IMapper mapper, IDataAccessProvider provider)
		{
			this._mapper = mapper;
			this._provider = provider;
		}

		// GET: api/values
		[HttpGet]
		public IEnumerable<Appointment> Get()
		{
			var appointments = this._provider.GetAppointments();
			return _mapper.Map<List<Appointment>>(appointments);
		}

		[HttpPost]
		public void AddAppointment([FromBody]Appointment appointment)
		{
			this._provider.AddAppointment(_mapper.Map<AppointmentEntity>(appointment));
		}
	}
}
