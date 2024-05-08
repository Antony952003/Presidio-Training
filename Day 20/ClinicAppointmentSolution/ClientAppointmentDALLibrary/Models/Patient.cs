using System;
using System.Collections.Generic;

namespace ClientAppointmentDALLibrary.Models
{
    public partial class Patient
    {
        public Patient()
        {
            Appointments = new HashSet<Appointment>();
        }

        public int Id { get; set; }
        public string? Name { get; set; }
        public string? MobNumber { get; set; }

        public virtual ICollection<Appointment> Appointments { get; set; }
    }
}
