using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class CartRepository : AbstractRepository<int, Cart>
    {
        public override async Task<Cart> Delete(int key)
        {
            Cart cart = await GetByKey(key);
            items.Remove(cart);
            return cart;
        }

        public override async Task<Cart> GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCartWithGiveIdException();
        }

        public override async Task<Cart> Update(Cart item)
        {
            try
            {
                Cart foundcart = await GetByKey(item.Id);
                int index = items.IndexOf(foundcart);
                items[index] = item;
                return item;
            }
            throw new NoCartWithGiveIdException();
            
        }
    }
}
