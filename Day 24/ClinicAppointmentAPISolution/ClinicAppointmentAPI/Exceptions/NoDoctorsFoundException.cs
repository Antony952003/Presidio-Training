using System.Runtime.Serialization;

namespace ClinicAppointmentAPI.Exceptions
{
    [Serializable]
    internal class NoDoctorsFoundException : Exception
    {
        readonly string message;
        public NoDoctorsFoundException()
        {
            message = "No Doctors are found !!!";
        }
        public override string Message => message;
    }
}