using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    public class UnauthorizedUserException : Exception
    {
        string message;
        public UnauthorizedUserException()
        {
            message = "Invalid username or password";
        }

        public override string Message => message;
    }
}