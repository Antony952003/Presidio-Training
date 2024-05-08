using System;
using System.Collections.Generic;

namespace ClientAppointmentDALLibrary.Models
{
    public partial class Doctor
    {
        public Doctor()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Specialization { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
