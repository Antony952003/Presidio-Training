using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary.Exceptions
{
    public class DuplicateCustomerException : Exception
    {
        readonly string message;
        public DuplicateCustomerException()
        {
            message = "This Customer Already Exists..";
        }
        public override string Message => message;
    }
}
