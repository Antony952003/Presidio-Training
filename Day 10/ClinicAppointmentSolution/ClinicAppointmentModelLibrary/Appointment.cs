using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentModelLibrary
{
    public class Appointment : IEquatable<Appointment>
    {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public int DoctorId { get; set; }
        public DateTime ApointmentDateTime { get; set; }
        public string AppointmentStatus { get; set; }
        public string MedicalInformation { get; set; }
        public bool Equals(Appointment? other)
        {
            return this.Id.Equals(other.Id);
        }
    }
}
