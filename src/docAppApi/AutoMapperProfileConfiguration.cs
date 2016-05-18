using AutoMapper;
using docAppApi.ViewModels;
using docAppDomain.Model;

namespace docAppApi
{
    public class AutoMapperProfileConfiguration : Profile
    {
		protected override void Configure()
		{
			CreateMap<Appointment, AppointmentEntity>().ReverseMap();
			//CreateMap<AppointmentEntity, Appointment>();
		}
	}
}
