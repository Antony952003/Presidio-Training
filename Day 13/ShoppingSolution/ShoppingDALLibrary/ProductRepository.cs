using ShoppingDALLibrary.Exceptions;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public class ProductRepository : AbstractRepository<int, Product>
    {
        public override async Task<Product> Add(Product item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                return item;
            }
            throw new DuplicateProductException();
        }
        public override async Task<Product> Delete(int key)
        {
            Product product = await GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override async Task<Product> GetByKey(int key)
        {
            foreach(var item in items)
            {
                if(item.Id == key)
                    return item;
            }
            throw new NoProductWithGivenIdException();
        }

        public override async Task<Product> Update(Product item)
        {
            Product product = await GetByKey(item.Id);
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == item.Id)
                {
                    items[i] = item;
                    return item;
                }
            }
            throw new NoProductWithGivenIdException();
        }
    }
}
