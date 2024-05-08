using System;
using System.Collections.Generic;

namespace ClientAppointmentDALLibrary.Models
{
    public partial class Appointment
    {
        public int Id { get; set; }
        public int? PatientId { get; set; }
        public int? DoctorId { get; set; }
        public DateTime? AppointmentDateTime { get; set; }
        public string? AppointmentStatus { get; set; }
        public string? MedicalInformation { get; set; }

        public virtual Doctor? Doctor { get; set; }
        public virtual Patient? Patient { get; set; }
    }
}
