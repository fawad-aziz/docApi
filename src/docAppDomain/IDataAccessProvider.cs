using docAppDomain.Model;
using System.Linq;

namespace docAppDomain
{
    public interface IDataAccessProvider
    {
		IQueryable<AppointmentEntity> GetAppointments();

		AppointmentEntity GetAppointment(int id);

		void AddAppointment(AppointmentEntity appointment);
	}
}
