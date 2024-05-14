using System.Runtime.Serialization;

namespace ClinicAppointmentAPI.Exceptions
{
    [Serializable]
    internal class NoSuchDoctorFoundException : Exception
    {
        readonly string message;
        public NoSuchDoctorFoundException()
        {
            message = "No Doctor with thi specialty is found!!";
        }
        public override string Message => message;

    }
}