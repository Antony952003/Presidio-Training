using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.Exceptions
{
    public class DuplicateDoctorFoundException : Exception
    {
        string msg;
        public DuplicateDoctorFoundException()
        {
            msg = "The Doctor already exists...";
        }
        public override string Message => msg;
    }
}
