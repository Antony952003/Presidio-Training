using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.Exceptions
{
    public class NoDoctorFoundException : Exception
    {
        string msg;
        public NoDoctorFoundException() {
            msg = "No Doctor is found...";
        
        }
        public override string Message => msg; 
    }
}
