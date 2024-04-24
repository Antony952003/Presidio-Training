using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingModelLibrary.Exceptions
{
    public class NoCartWithGiveIdException : Exception
    {
        string msg;
        public NoCartWithGiveIdException()
        {
            msg = "No cart for the given Id ";
        }
        public override string Message => msg; 
    }

}
