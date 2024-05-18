using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoRequestsOpenException : Exception
    {
        readonly string message;
        public NoRequestsOpenException()
        {
            message = "No Requests are open at the moment!!";
        }
        public override string Message => message;

    }
}