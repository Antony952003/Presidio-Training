using ClientAppointmentDALLibrary;
using ClientAppointmentDALLibrary.Models;
using ClinicAppointmentBLLibrary;
using ClinicAppointmentBLLibrary.Exceptions;
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
        [Test]
        public void AddPatientFail()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            patientService.AddPatient(patient);
            var exception = Assert.Throws<DuplicatePatientException>(() =>  patientService.AddPatient(patient));
            Assert.AreEqual(exception.Message, $"The Patient Name {patient.Name} Already exists in the repository...");

        }
        [Test]
        public void UpdatePatientSuccess()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            patientService.AddPatient(patient);
            patient.Name = "jeson";
            patientService.UpdatePatient(patient);
            Assert.AreEqual(patient.Name, "jeson");
        }
        [Test]
        public void UpdatePatientFail()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            patientService.AddPatient(patient);
            patient.Name = "jeson";
            patientService.UpdatePatient(patient);
            Assert.AreEqual(patient.Name, "jeson");
        }
        [Test]
        public void DeletePatientSuccess()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            Patient patient1 = new Patient() { Name = "Antony Jeson", MobNumber = "90809592016" };
            patientService.AddPatient(patient);
            patientService.AddPatient(patient1);
            patientService.DeletePatient(patient);
            List<Patient> patients = patientService.GetAllPatients();
            Assert.AreEqual(patients.Count, 1);
        }
        [Test]
        public void DeletePatientFail()
        {
            Patient patient = new Patient() { Name = "Antony", MobNumber = "90809501016" };
            var exception = Assert.Throws<NoPatientFoundException>(() =>  patientService.DeletePatient(patient));
            Assert.AreEqual(exception.Message, $"There is no patient with name : {patient.Name}");
        }
    }
}
