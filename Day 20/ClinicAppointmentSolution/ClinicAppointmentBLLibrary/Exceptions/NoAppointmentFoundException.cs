using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.Exceptions
{
    public class NoAppointmentFoundException : Exception
    {
        string msg;
        public NoAppointmentFoundException()
        {
            msg = "There is no Appointment found..";
        }
        public override string Message => msg; 
    }
}
