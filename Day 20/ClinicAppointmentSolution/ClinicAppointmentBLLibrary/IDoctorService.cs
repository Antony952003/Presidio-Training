using ClientAppointmentDALLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary

{
    public interface IDoctorService
    {
        int AddDoctor(Doctor doctor);
        Doctor GetDoctorBySpecialization(string Specialization);
        bool IsthereandoctorAppointment(Doctor doctor);
        Doctor GetDoctorById(int id);
        List<Appointment> GetDoctorAppointments(int Id);
        Doctor DeleteDoctor(Doctor doctor);
        List<Doctor> GetAllDoctors();
    }
}
