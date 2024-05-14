using ClinicAppointmentAPI.Exceptions;
using ClinicAppointmentAPI.Interfaces;
using ClinicAppointmentAPI.Models;

namespace ClinicAppointmentAPI.Services
{
    public class DoctorBasicService : IDoctorService
    {
        IRepository<int, Doctor> _repository;
        public DoctorBasicService(IRepository<int, Doctor> repository)
        {
            _repository = repository;
        }
        public async Task<Doctor> GetDoctorBySpecialization(string specialization)
        {
            var result = await _repository.Get();
            var specializeddoctor = result.ToList().Find(x => x.Specialization == specialization);
            if(specializeddoctor != null)
            {
                return specializeddoctor;
            }
            throw new NoSuchDoctorFoundException();
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            var result = await _repository.Get();
            if(result != null)
            {
                return result;
            }
            throw new NoDoctorsFoundException();
        }

        public async Task<Doctor> UpdateDoctorExperience(int id, double experience)
        {
            var doctor = await _repository.Get(id);
            if(doctor != null)
            {
                doctor.Experience = experience;
                _repository.Update(doctor);
                return doctor;
            }
            throw new NoDoctorsFoundException();

        }
    }
}
