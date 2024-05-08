using ClientAppointmentDALLibrary;
using ClientAppointmentDALLibrary.Models;
using ClinicAppointmentBLLibrary;
using ClinicAppointmentBLLibrary.Exceptions;


namespace ClinicAppointmentBlTest
{
    public class DoctorBlTest
    {
        IRepository<int, Doctor> repository;
        IDoctorService doctorService;
        [SetUp]
        public void Setup()
        {
            repository = new DoctorRepository();
            doctorService = new DoctorBl(repository);
        }


        [Test]
        public void GetDoctorBySpecialization()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "Dentist" };
            repository.Add(doctor);
            doctor = new Doctor() { Name = "Jeson", Specialization = "ENT" };
            repository.Add(doctor);
            var result = doctorService.GetDoctorBySpecialization("Dentist");
            Assert.AreEqual(result.Specialization, "Dentist");
        }
        [Test]
        public void GetDoctorBySpecializationException()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "Dentist" };
            repository.Add(doctor);
            doctor = new Doctor() { Name = "Jeson", Specialization = "ENT" };
            repository.Add(doctor);
            var exception = Assert.Throws<NoDoctorFoundException>(() => doctorService.GetDoctorBySpecialization("Scientist"));
        }
        [Test]
        public void GetSuccessDoctorById()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "Dentist" };
            repository.Add(doctor);
            doctor = new Doctor() { Name = "Jeson", Specialization = "ENT" };
            repository.Add(doctor);
            var result = doctorService.GetDoctorById(1);
            Assert.IsNotNull(result);
        }
        [Test]
        public void GetDoctorByIdException()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "Dentist" };
            repository.Add(doctor);
            doctor = new Doctor() { Name = "Jeson", Specialization = "ENT" };
            repository.Add(doctor);
            var exception = Assert.Throws<NoDoctorFoundException>(() => doctorService.GetDoctorById(3));
            Assert.AreEqual(exception.Message, "No Doctor is found...");
        }
        [Test]
        public void GetFailDoctorById()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "Dentist" };
            repository.Add(doctor);
            doctor = new Doctor() { Name = "Jeson", Specialization = "ENT" };
            repository.Add(doctor);
            var result = Assert.Throws<NoDoctorFoundException>(() => doctorService.GetDoctorById(3));
            Assert.AreEqual(result.Message, "No Doctor is found...");
        }
        [Test]
        public void GetAllDoctorsSuccess()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "Dentist" };
            repository.Add(doctor);
            doctor = new Doctor() { Name = "Jeson", Specialization = "ENT" };
            repository.Add(doctor);
            var result = doctorService.GetAllDoctors();
            Assert.AreEqual(result.Count, 2);
        }
        [Test]
        public void GetAllDoctorFail()
        {
            var exception = Assert.Throws<NoDoctorFoundException>(() => doctorService.GetAllDoctors());
            Assert.AreEqual(exception.Message, "No Doctor is found...");
        }

        [Test]
        public void AddDoctorFail()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "ENT" };
            doctorService.AddDoctor(doctor);
            var exception = Assert.Throws<DuplicateDoctorFoundException>(() => doctorService.AddDoctor(doctor));
            Assert.AreEqual(exception.Message, "The Doctor already exists...");
        }
        [Test]
        public void AddDoctorSuccess()
        {
            Doctor doctor = new Doctor() { Name = "Antony", Specialization = "ENT" };
            doctorService.AddDoctor(doctor);
            Assert.AreEqual(1, doctor.Id);
        }
    }
}