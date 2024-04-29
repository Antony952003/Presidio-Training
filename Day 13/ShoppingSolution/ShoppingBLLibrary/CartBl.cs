using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CartBl : ICartService
    {
        IRepository<int, Cart> _cartrepository;
        IRepository<int, Product> _productrepository;
        public CartBl(IRepository<int, Cart> cartrepository, IRepository<int, Product> productrepository) {
            _cartrepository = cartrepository;
            _productrepository = productrepository;

        }

        public async Task<int> AddCartItem(int cartId, CartItem cartItem)
        {
            var foundCart = await _cartrepository.GetByKey(cartId);
            var productfound = await _productrepository.GetByKey(cartItem.ProductId);
            if((productfound.QuantityInHand - cartItem.Quantity) < 0)
            {
                throw new RequiredQuantityNotAvailableException();
            }
            productfound.QuantityInHand -= cartItem.Quantity;
            foundCart.CartItems.Add(cartItem);
            var cartItemAdded = _cartrepository.Update(foundCart);
            _productrepository.Update(productfound);
            return cartId;
        }
        public async Task<int> AddCart(Cart cart)
        {
            Cart addedcart = await _cartrepository.Add(cart);
            return addedcart.Id;
        }

        public async Task<Cart> GetCartByCustomerID(int customerId)
        {
            var AllCarts = await _cartrepository.GetAll();
            var foundCart = AllCarts.Find((cart) => cart.CustomerId == customerId);
                if (foundCart != null)
                    return foundCart;

                throw new NoCartWithGiveIdException();

        }

        public async Task<Cart> GetCartById(int cartId)
        {
            try
            {
                var foundCart = await _cartrepository.GetByKey(cartId);
                return foundCart;
            }
            catch(Exception ex)
            {
                throw;
            }
        }

        public async Task<CartItem> RemoveItem(int cartid, CartItem cartItem)
        {
            var foundCart = await _cartrepository.GetByKey(cartid);
            if (foundCart.CartItems.Contains(cartItem))
            {
                foundCart.CartItems.Remove(cartItem);
                var updatedcart = await _cartrepository.Update(foundCart);
                return cartItem;
            }
            throw new CartItemNotFoundException();
        }

        public async Task<double> TotalAmountForCartItems(int cartId)
        {
            var foundcart = await _cartrepository.GetByKey(cartId);
            double total = 0;
            foreach (var item in foundcart.CartItems)
            {
                total += item.Quantity * item.Price;
            }
            return total;
        }

        public async Task<CartItem> UpdateQuantity(int quantity, CartItem cartItem, int cartId)
        {
            var foundcart = await _cartrepository.GetByKey(cartId);
            for(int i = 0; i < foundcart.CartItems.Count; i++)
            {
                if (foundcart.CartItems[i].ProductId == cartItem.ProductId)
                {
                    if(quantity > ((cartItem.Product.QuantityInHand) + (cartItem.Quantity)))
                        throw new MaximumQuantityExceededException();
                    foundcart.CartItems[i].Quantity = quantity;
                    var foundproduct = cartItem.Product;
                    foundproduct.QuantityInHand = ((foundproduct.QuantityInHand) + (cartItem.Quantity)) - (quantity);
                    _productrepository.Update(foundproduct);
                }
            }
            _cartrepository.Update(foundcart);
            return cartItem;
        }
        public async Task<CartItem> GetCartItem(int cartId, int productId)
        {
            var foundcart = await _cartrepository.GetByKey(cartId);
            var foundItem = foundcart.CartItems.Find((item) => item.ProductId == productId);
            return foundItem;
        }

        public async Task<bool> ValidateCart(List<CartItem> cartitems)
        {
            var ispresent = cartitems.Count > 0;
            if (!ispresent) throw new NoItemsInCartException();
            return true;
        }
        public async Task<List<CartItem>> GetAllCartItems(int cartId)
        {
            Cart foundcart = await _cartrepository.GetByKey(cartId);
            return foundcart.CartItems;
        }
    }
}
