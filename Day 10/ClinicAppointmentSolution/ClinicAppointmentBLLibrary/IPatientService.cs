using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public interface IPatientService
    {
        int AddPatient(Patient patient);
        Appointment AddAppointmentWithDoctor(Patient patient, Doctor doctor, DateTime newDateTime);
        Patient DeletePatient(Patient patient);
        List<Patient> GetAllPatients();
        Patient UpdatePatient(Patient patient);
        void RescheduleAppointmentForPatient(int appointmentId, DateTime newDateTime);
    }
}
