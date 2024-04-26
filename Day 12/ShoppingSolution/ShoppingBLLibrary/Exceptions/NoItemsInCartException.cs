using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class NoItemsInCartException : Exception
    {
        string msg;
        public NoItemsInCartException()
        {
            msg = "No Items in the Cart..";
        }
        public override string Message => msg;
    }
}
