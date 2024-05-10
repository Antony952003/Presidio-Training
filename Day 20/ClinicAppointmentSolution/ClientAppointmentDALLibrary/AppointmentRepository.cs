using ClientAppointmentDALLibrary.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        dbDoctorPatientContext _context;
        public AppointmentRepository(dbDoctorPatientContext context)
        {
            _context = context;
        }
        int GenerateId()
        {
            if (_context.Appointments.Count() == 0)
                return 1;
            int id = _context.Appointments.Max(x => x.Id);
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
            if (_context.Appointments.Contains(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _context.Add(item);
            _context.SaveChanges();
            return item;
        }

        public Appointment Delete(int key)
        {
            var FoundAppointment = _context.Appointments.ToList().Find(x => x.Id == key);
            if (FoundAppointment != null)
            {
                _context.Appointments.Remove(FoundAppointment);
                _context.SaveChanges();
                return FoundAppointment;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            var FoundAppointment = _context.Appointments.ToList().Find(x => x.Id == key);
            if (FoundAppointment != null) { return FoundAppointment; }
            return null;
        }

        public List<Appointment> GetAll()
        {
           return _context.Appointments.ToList();
        }

        public Appointment Update(Appointment item)
        {
            var FoundAppointment = _context.Appointments.ToList().Find(x => x.Id == item.Id);
            if (FoundAppointment != null)
            {
                _context.Appointments.Update(FoundAppointment);
                _context.SaveChanges();
                return item;
            }
            return null;
        }
    }
}
