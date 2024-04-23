using ClinicAppointmentModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary
{
    public interface IAppointmentService
    {
        List<Appointment> GetAllAppointments();

        Appointment GetAppointmentById(int appointmentId);

        bool IsthereanAppointment(int patientId);

        Appointment UpdateAppointment(Appointment appointment);

        Appointment CancelAppointment(int appointmentId);

        List<Appointment> GetAppointmentsForDoctor(int doctorId);

        List<Appointment> GetAppointmentsForPatient(int patientId);
    }
}
