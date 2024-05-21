using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class AdminOnlyOperationException : Exception
    {
        readonly string message;
        public AdminOnlyOperationException()
        {
            message = "This Operation is only done by a Admin, Login as a Admin";
        }
        public override string Message => message;
    }
}