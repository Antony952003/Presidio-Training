using System.Runtime.Serialization;

namespace EmployeeRequestTrackerAPI.Exceptions
{
    [Serializable]
    public class NoEmployeesFoundException : Exception
    {
        readonly string message;
        public NoEmployeesFoundException()
        {
            message = "No Employees are found!!";
        }
        public override string Message => message;


    }
}