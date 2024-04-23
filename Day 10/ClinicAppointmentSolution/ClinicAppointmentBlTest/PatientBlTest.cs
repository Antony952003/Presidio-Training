using ClientAppointmentDALLibrary;
using ClinicAppointmentBLLibrary;
using ClinicAppointmentBLLibrary.Exceptions;
using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBlTest
{
    public class PatientBlTest
    {
        IRepository<int, Appointment> appointmentrepository;
        IRepository<int, Patient> patientRepository;
        IPatientService patientService;
        [SetUp]
        public void Setup()
        {
            patientRepository = new PatientRepository();
            patientService = new PatientBl(patientRepository, appointmentrepository);
        }
        [Test]
        public void AddPatientSuccess()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            patientService.AddPatient(patient);
            Assert.AreEqual(1, patient.Id);
        }
        public void AddPatientFail()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            patientService.AddPatient(patient);
            var exception = Assert.Throws<DuplicatePatientException>(() =>  patientService.AddPatient(patient));
            Assert.AreEqual(exception.Message, $"The Patient Name {patient.Name} Already exists in the repository...");

        }
        public void UpdatePatientSuccess()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            patientService.AddPatient(patient);
            patient.Name = "jeson";
            patientService.UpdatePatient(patient);
            Assert.AreEqual(patient.Name, "jeson");
        }
        public void UpdatePatientFail()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            patientService.AddPatient(patient);
            patient.Name = "jeson";
            patientService.UpdatePatient(patient);
            Assert.AreEqual(patient.Name, "jeson");
        }

    }
}
