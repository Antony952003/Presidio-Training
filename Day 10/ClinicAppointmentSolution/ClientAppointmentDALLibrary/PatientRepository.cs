using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointmentDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        readonly Dictionary<int, Patient> patients;

        public PatientRepository()
        {
            patients = new Dictionary<int, Patient>();
        }
        int GenerateId()
        {
            if (patients.Count == 0)
                return 1;
            int id = patients.Keys.Max();
            return ++id;
        }
        public Patient Add(Patient item)
        {
            if (patients.ContainsValue(item))
            {
                return null;
            }
            item.Id = GenerateId();
            patients.Add(item.Id, item);
            return item;
        }

        public Patient Delete(int key)
        {
            if (patients.ContainsKey(key))
            {
                var patient = patients[key];
                patients.Remove(key);
                return patient;
            }
            return null;
        }

        public Patient Get(int key)
        {
            if (patients.ContainsKey(key))
            {
                return patients[key];
            }
            return null;
        }

        public List<Patient> GetAll()
        {
            if (patients.Count == 0)
                return null;
            return patients.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (patients.ContainsKey(item.Id))
            {
                patients[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}
