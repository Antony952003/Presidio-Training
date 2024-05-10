using ClientAppointmentDALLibrary.Models;
using ClientAppointmentDALLibrary;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientAppointmentDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        dbDoctorPatientContext _context;

        public PatientRepository(dbDoctorPatientContext context)
        {
            _context = context;
        }
        int GenerateId()
        {
            if (_context.Patients.Count() == 0)
                return 1;
            int id = _context.Patients.Max(x => x.Id);
            return ++id;
        }
        public Patient Add(Patient item)
        {
            if (_context.Patients.Contains(item))
            {
                return null;
            }
            item.Id = GenerateId();
            _context.Add(item);
            return item;
        }

        public Patient Delete(int key)
        {
            var FoundPatient = _context.Patients.ToList().Find(x => x.Id == key);
            if (FoundPatient != null)
            {
                _context.Patients.Remove(FoundPatient);
                return FoundPatient;
            }
            return null;
        }

        public Patient Get(int key)
        {
            var FoundPatient = _context.Patients.ToList().Find(x => x.Id == key);
            if (FoundPatient != null) { return FoundPatient; }
            return null;
        }

        public List<Patient> GetAll()
        {
            return _context.Patients.ToList();
        }

        public Patient Update(Patient item)
        {
            var FoundPatient = _context.Patients.ToList().Find(x => x.Id == item.Id);
            if (FoundPatient != null)
            {
                _context.Patients.Update(FoundPatient);
                return item;
            }
            return null;
        }
    }
}
