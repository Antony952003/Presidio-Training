using PizzaAPI.Models;
using System.Runtime.Serialization;

namespace PizzaAPI.Exceptions
{
    [Serializable]
    internal class NoSuchPizzaIsFoundException : Exception
    {
        string message;

        public NoSuchPizzaIsFoundException(string pizza)
        {
            message = $"No Pizza of name {pizza} is found ";
        }
        public NoSuchPizzaIsFoundException()
        {
            message = "No Such pizza is found!!";
        }
        public override string Message => message;


    }
}