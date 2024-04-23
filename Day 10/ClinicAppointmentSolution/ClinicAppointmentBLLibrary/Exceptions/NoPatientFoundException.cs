using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicAppointmentBLLibrary.Exceptions
{
    public class NoPatientFoundException : Exception
    {
        string msg;
        public NoPatientFoundException(string name)
        {
            msg = $"There is no patient with name : {name}";
        }
        public NoPatientFoundException()
        {
            msg = $"There are no patients found...";
        }
        public override string Message => msg;
    }
}
