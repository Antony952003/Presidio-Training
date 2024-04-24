using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBl : ICartService
    {
        CartRepository _cartrepository;
        public CartBl(CartRepository cartrepository) {
            _cartrepository = cartrepository;
        }
        public int AddCartItem(Cart cart, CartItem cartItem)
        {
            if(cartItem.Quantity < 5)
            {
                cart.CartItems.Add(cartItem);
            }
            throw new MaximumQuantityExceededException();
        }

        public CartItem RemoveItem(int cartid, CartItem cartItem)
        {
            Cart cart = _cartrepository.GetByKey(cartid);
            if(cart.CartItems.Contains(cartItem))
            {
                cart.CartItems.Remove(cartItem);
                _cartrepository.Update(cart);
                return cartItem;
            }
            throw new CartItemNotFoundException();
        }
        public bool ValidateCart(List<CartItem> cartitems)
        {
            bool ans = true;
            cartitems.ForEach((cartitem) =>
            {
                if(cartitem.Quantity > 5) {
                    ans = false;
                }
            });
            return ans;
        }
        public CartItem UpdateQuantity(int quantity, CartItem cartItem,int cartid)
        {
            Cart cart = _cartrepository.GetByKey(cartid);
            if (cart.CartItems.Contains(cartItem))
            {
                var founditem = cart.CartItems.Find((item) => item.ProductId == cartItem.ProductId);
                if(founditem != null)
                {
                    founditem.Quantity = quantity;
                    _cartrepository.Update(cart);
                    return founditem;
                }
            }
            throw new CartItemNotFoundException();

        }
        public CartItem GetCartItem(int cartid, CartItem cartItem)
        {
            Cart cart = _cartrepository.GetByKey(cartid);
            CartItem foundItem = cart.CartItems.Find(item => item.ProductId == cartItem.ProductId);
            if(foundItem != null)
            {
                return foundItem;
            }
            throw new CartItemNotFoundException();
        }
        public double TotalAmountForCartItems(List<Product> products)
        {
            double total = 0;
            products.ForEach((cartItem) => {

                total += cartItem.Price * cartItem.QuantityInHand;
                
            });
            total += (total < 100) ? 100 : 0;
            total *= ((products.Count == 3) && (total == 1500)) ? 0.95 : 1;
            return total;
        }
    }
}
