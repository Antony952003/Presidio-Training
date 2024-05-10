
using ClientAppointmentDALLibrary;
using ClientAppointmentDALLibrary.Models;

namespace ClientDoctorDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor> 
    {
        dbDoctorPatientContext _context;

        public DoctorRepository(dbDoctorPatientContext context)
        {
            _context = context;
        }
        int GenerateId()
        {
            if (_context.Doctors.Count() == 0)
                return 1;
            int id = _context.Doctors.Max(x => x.Id);
            return ++id;
        }
        public Doctor Add(Doctor item)
        {
            if (_context.Doctors.Contains(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _context.Add(item);
            return item;
        }

        public Doctor Delete(int key)
        {
            var FoundDoctor = _context.Doctors.ToList().Find(x => x.Id == key);
            if (FoundDoctor != null)
            {
                _context.Doctors.Remove(FoundDoctor);
                return FoundDoctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            var FoundDoctor = _context.Doctors.ToList().Find(x => x.Id == key);
            if (FoundDoctor != null) { return FoundDoctor; }
            return null;
        }

        public List<Doctor> GetAll()
        {
           return _context.Doctors.ToList();
        }

        public Doctor Update(Doctor item)
        {
            var FoundDoctor = _context.Doctors.ToList().Find(x => x.Id == item.Id);
            if (FoundDoctor != null)
            {
                _context.Doctors.Update(FoundDoctor);
                return item;
            }
            return null;
        }
    }
}
