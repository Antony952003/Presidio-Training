using System.Runtime.Serialization;

namespace ClinicAppointmentBLLibrary.Exceptions
{
    public class DuplicatePatientException : Exception
    {
        string msg;
        public DuplicatePatientException(string name)
        {
            msg = $"The Patient Name {name} Already exists in the repository...";
        }
        public override string Message => msg;


    }
}