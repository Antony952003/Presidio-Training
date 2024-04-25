using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class RequiredQuantityNotAvailableException : Exception
    {
        string msg;
        public RequiredQuantityNotAvailableException() {
            msg = "The Required amount of the item is not available...";
        }
        public override string Message => msg;
    }
}
