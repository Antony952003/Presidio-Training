using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary.Exceptions
{
    public class DuplicateProductException : Exception
    {
        readonly string message;
        public DuplicateProductException()
        {
            message = "This Product Already Exists..";
        }
        public override string Message => message;
    }
}
