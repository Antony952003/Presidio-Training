using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    public class NoPizzaFoundException : Exception
    {
        readonly string message;
        public NoPizzaFoundException()
        {
            message = "No Pizza are available!!";
        }
        public override string Message => message;


    }
}