using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    public class NoSuchEmployeeException : Exception
    {
        readonly string message;
        public NoSuchEmployeeException()
        {
            message = "No such employee is found";
        }

        public override string Message => message;
    }
}