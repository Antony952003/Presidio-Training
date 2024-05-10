using ClientAppointmentDALLibrary;
using ClientAppointmentDALLibrary.Models;
using ClinicAppointmentBLLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public class PatientBl : IPatientService
    {
        IRepository<int, Patient> _patientrepository;
        IRepository<int, Appointment> _appointmentrepository;
        public PatientBl()
        {
            _patientrepository = new PatientRepository(new dbDoctorPatientContext());
            _appointmentrepository = new AppointmentRepository(new dbDoctorPatientContext());
        }
        public Appointment AddAppointmentWithDoctor(Patient patient, Doctor doctor, DateTime newDateTime)
        {
            throw new NotImplementedException();
        }

        public int AddPatient(Patient patient)
        {
            var result = _patientrepository.Add(patient);
            if(result != null)
            {
                return result.Id;
            }
            throw new DuplicatePatientException(patient.Name);
        }

        public Patient DeletePatient(Patient patient)
        {
            var result = _patientrepository.Delete(patient.Id);
            if(result != null)
            {
                var deletedappointment = _appointmentrepository?.GetAll()?.Find(appointment => appointment.PatientId == patient.Id);
                if(deletedappointment != null)
                {
                    _appointmentrepository.Delete(deletedappointment.Id);
                }
                return patient;
            }
            throw new NoPatientFoundException(patient.Name);
        }

        public List<Patient> GetAllPatients()
        {
            var result = _patientrepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new NoPatientFoundException();
        }

        public void RescheduleAppointmentForPatient(int appointmentId, DateTime newDateTime)
        {
            Appointment foundappointment = _appointmentrepository.Get(appointmentId);
            if (foundappointment != null)
            {
                foundappointment.AppointmentDateTime = newDateTime;
                _appointmentrepository.Update(foundappointment);
                return;
            }
            throw new NoPatientFoundException();

        }

        public Patient UpdatePatient(Patient patient)
        {
            var result = _patientrepository.Update(patient);
            if(result != null)
            {
                return result;
            }
            throw new NoPatientFoundException(patient.Name) ;
        }
    }
}
