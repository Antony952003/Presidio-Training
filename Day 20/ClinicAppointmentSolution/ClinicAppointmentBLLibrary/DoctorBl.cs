using ClientAppointmentDALLibrary.Models;
using ClientAppointmentDALLibrary;
using ClinicAppointmentBLLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ClientDoctorDALLibrary;

namespace ClinicAppointmentBLLibrary
{
    public class DoctorBl : IDoctorService
    {
        IRepository<int, Doctor> _doctorrepository;
        IRepository<int, Appointment> _appointmentRepository;
        public DoctorBl()
        {
            _doctorrepository = new DoctorRepository(new dbDoctorPatientContext());
            _appointmentRepository = new AppointmentRepository(new dbDoctorPatientContext());
        }

        public int AddDoctor(Doctor doctor)
        {
            var result = _doctorrepository.Add(doctor);
            if(result != null)
            {
                return result.Id;
            }
            throw new DuplicateDoctorFoundException();
        }

        public Doctor DeleteDoctor(Doctor doctor)
        {
            var result = _doctorrepository.Delete(doctor.Id);
            if(result != null)
            {
                var foundappointment = _appointmentRepository.GetAll().Find(app => app.DoctorId == doctor.Id);
                var result2 = _appointmentRepository.Delete(foundappointment.Id);
                return result;
            }
            throw new NoDoctorFoundException();
        }

        public List<Doctor> GetAllDoctors()
        {
            var result = _doctorrepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new NoDoctorFoundException();
        }


        public List<Appointment> GetDoctorAppointments(int Id)
        {
            var result = _appointmentRepository.GetAll().FindAll(app => app.DoctorId == Id);
            if (result.Any())
            {
                return result;
            }
            throw new NoAppointmentFoundException();
        }

        public Doctor GetDoctorById(int id)
        {
            var result = _doctorrepository.Get(id);
            if (result != null)
            {
                return result;
            }
            throw new NoDoctorFoundException();
        }

        public Doctor GetDoctorBySpecialization(string specialization)
        {
            var result = _doctorrepository.GetAll().Find(doc => doc.Specialization == specialization);
            if(result != null)
            {
                return result;
            }
            throw new NoDoctorFoundException();
        }

        public bool IsthereandoctorAppointment(Doctor doctor)
        {
            var result = _appointmentRepository.GetAll().Find(app => app.DoctorId == doctor.Id);
            if(result != null)
            {
                return true;
            }
            return false;

        }
    }
}
