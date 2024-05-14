using ClinicAppointmentAPI.Exceptions;
using ClinicAppointmentAPI.Interfaces;
using ClinicAppointmentAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ClinicAppointmentAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        IDoctorService _service;
        public DoctorController(IDoctorService service) {
            _service = service;
        }
        [HttpGet]
        public async Task<IEnumerable<Doctor>> GetAllDoctors()
        {
            var result = await _service.GetDoctors();
            return result.ToList();
        }
        [HttpPut]
        public async Task<Doctor> UpdateExperince(int id, double experience)
        {
            try
            {
                var result = await _service.UpdateDoctorExperience(id, experience);
                return result;
            }
            catch (NoDoctorsFoundException ex) {
                NotFound(ex.Message);
                throw new NoDoctorsFoundException();
            }
        }
        [HttpGet]
        [Route("GetBySpecialization")]
        public async Task<Doctor> GetDoctorBySpecialty(string specialization)
        {
            try
            {
                var result = await _service.GetDoctorBySpecialization(specialization);
                return result;
            }
            catch (NoSuchDoctorFoundException ex)
            {
                NotFound(ex.Message);
                throw new NoSuchDoctorFoundException();
            }
        }
    }
}
