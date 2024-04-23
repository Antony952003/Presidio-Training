using ClinicAppointmentModelLibrary;

namespace ClientAppointmentDALLibrary
{
    public class DoctorRepository : IRepository<int, Doctor> 
    {
        readonly Dictionary<int, Doctor> doctors;

        public DoctorRepository()
        {
            doctors = new Dictionary<int, Doctor>();
        }
        int GenerateId()
        {
            if (doctors.Count == 0)
                return 1;
            int id = doctors.Keys.Max();
            return ++id;
        }
        public Doctor Add(Doctor item)
        {
            if (doctors.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            doctors.Add(item.Id, item);
            return item;
        }

        public Doctor Delete(int key)
        {
            if(doctors.ContainsKey(key))
            {
                var doctor = doctors[key];
                doctors.Remove(key);
                return doctor;
            }
            return null;
        }

        public Doctor Get(int key)
        {
            if(doctors.ContainsKey(key))
            {
                return doctors[key];
            }
            return null;
        }

        public List<Doctor> GetAll()
        {
            if (doctors.Count == 0)
                return null;
            return doctors.Values.ToList();
        }

        public Doctor Update(Doctor item)
        {
            if (doctors.ContainsKey(item.Id))
            {
                doctors[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
