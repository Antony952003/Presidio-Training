using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary.Exceptions
{
    public class NoCustomerInException : Exception
    {
        string msg;
        public NoCustomerInException()
        {
            msg = "No Customer in the database add customer";
        }
        public override string Message => msg; 
    }
}
