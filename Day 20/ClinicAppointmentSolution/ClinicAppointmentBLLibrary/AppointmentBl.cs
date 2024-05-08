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
    public class AppointmentBl : IAppointmentService
    {
        AppointmentRepository _appointmentRepository;
        public AppointmentBl()
        {
            _appointmentRepository = new AppointmentRepository();
        }
        public Appointment CancelAppointment(int appointmentId)
        {
            Appointment foundappointment = _appointmentRepository.Get(appointmentId);
            if (foundappointment == null)
            {
                foundappointment.AppointmentStatus = "Cancelled";
                _appointmentRepository.Update(foundappointment);
                return foundappointment;
            }
            throw new NoAppointmentFoundException();
        }

        public List<Appointment> GetAllAppointments()
        {
            var result = _appointmentRepository.GetAll();
            if(result != null)
            {
                return result;
            }
            throw new NoAppointmentFoundException();
        }

        public Appointment GetAppointmentById(int appointmentId)
        {
            var result = _appointmentRepository.Get(appointmentId);
            if(result != null)
            {
                return result;
            }
            throw new NoAppointmentFoundException();

        }

        public List<Appointment> GetAppointmentsForDoctor(int doctorId)
        {
            var result = _appointmentRepository.GetAll().FindAll(ap => ap.DoctorId == doctorId);
            if(result != null)
            {
                return result;
            }
            throw new NoAppointmentFoundException();
        }

        public List<Appointment> GetAppointmentsForPatient(int patientId)
        {
            var result = _appointmentRepository.GetAll().FindAll(ap => ap.PatientId == patientId);
            if (result != null)
            {
                return result;
            }
            throw new NoAppointmentFoundException();
        }

        public bool IsthereanAppointment(int patientId)
        {
            var result = _appointmentRepository.GetAll().Find(ap => ap.PatientId == patientId);
            if(result != null )
            {
                return true;
            }
            return false;
        }

        public Appointment UpdateAppointment(Appointment appointment)
        {
            var result = _appointmentRepository.Update(appointment);
            if(result != null )
            {
                return result;
            }
            throw new NoAppointmentFoundException();
        }
    }
}
