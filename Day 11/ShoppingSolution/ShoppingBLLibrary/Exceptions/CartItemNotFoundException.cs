using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary.Exceptions
{
    public class CartItemNotFoundException : Exception
    {
        string msg;
        public CartItemNotFoundException()
        {
            msg = "The CartItem is not Found in the cart";
        }
        public override string Message => msg;
    }
}
