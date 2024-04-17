using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointmentDALLibrary
{
    public class AppointmentRepository : IRepository<int, Appointment>
    {
        readonly Dictionary<int, Appointment> appointments;

        public AppointmentRepository()
        {
            appointments = new Dictionary<int, Appointment>();
        }
        int GenerateId()
        {
            if (appointments.Count == 0)
                return 1;
            int id = appointments.Keys.Max();
            return ++id;
        }
        public Appointment Add(Appointment item)
        {
            if (appointments.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            appointments.Add(item.Id, item);
            return item;
        }

        public Appointment Delete(int key)
        {
            if (appointments.ContainsKey(key))
            {
                var appointment = appointments[key];
                appointments.Remove(key);
                return appointment;
            }
            return null;
        }

        public Appointment Get(int key)
        {
            if (appointments.ContainsKey(key))
            {
                return appointments[key];
            }
            return null;
        }

        public List<Appointment> GetAll()
        {
            if (appointments.Count == 0)
                return null;
            return appointments.Values.ToList();
        }

        public Appointment Update(Appointment item)
        {
            if (appointments.ContainsKey(item.Id))
            {
                appointments[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
