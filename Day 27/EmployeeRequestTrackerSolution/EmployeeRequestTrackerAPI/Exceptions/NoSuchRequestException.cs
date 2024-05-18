using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    public class NoSuchRequestException : Exception
    {
        readonly string _message;
        public NoSuchRequestException()
        {
            _message = "No Such Request Number Exists";
        }
        public override string Message => _message;




    }
}