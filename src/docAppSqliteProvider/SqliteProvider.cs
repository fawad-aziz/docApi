﻿using docAppDomain;
using System.Linq;
using docAppDomain.Model;

namespace docAppSqliteProvider
{
	public class SqliteProvider : IDataAccessProvider
	{
		private readonly docAppContext _context;

		public SqliteProvider(docAppContext context)
		{
			this._context = context;
		}

		public AppointmentEntity GetAppointment(int id)
		{
			return this._context.Appointments.First(t => t.Id == id);
		}

		public IQueryable<AppointmentEntity> GetAppointments()
		{
			return this._context.Appointments;
		}

		public void AddAppointment(AppointmentEntity appointment)
		{
			_context.Appointments.Add(appointment);
			_context.SaveChanges();
		}
	}
}
