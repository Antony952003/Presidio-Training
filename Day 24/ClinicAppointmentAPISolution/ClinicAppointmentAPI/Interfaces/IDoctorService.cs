using ClinicAppointmentAPI.Models;

namespace ClinicAppointmentAPI.Interfaces
{
    public interface IDoctorService
    {
        public Task<Doctor> GetDoctorBySpecialization(string specialization);
        public Task<Doctor> UpdateDoctorExperience(int id, double experience);
        public Task<IEnumerable<Doctor>> GetDoctors();
    }
}
