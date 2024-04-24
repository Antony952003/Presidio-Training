using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class MaximumQuantityExceededException : Exception
    {
        string msg;
        public MaximumQuantityExceededException() {
            msg = "The Maximum Quantity for the Item has been exceeded it must be below 5";
        }
        public override string Message => msg;
    }
}
