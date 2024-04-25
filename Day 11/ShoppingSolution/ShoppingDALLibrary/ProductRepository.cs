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
        public override Product Add(Product item)
        {
            if (!items.Contains(item))
            {
                items.Add(item);
                return item;
            }
            throw new DuplicateProductException();
        }
        public override Product Delete(int key)
        {
            Product product = GetByKey(key);
            if (product != null)
            {
                items.Remove(product);
            }
            return product;
        }

        public override Product GetByKey(int key)
        {
            foreach(var item in items)
            {
                if(item.Id == key)
                    return item;
            }
            throw new NoProductWithGivenIdException();
        }

        public override Product Update(Product item)
        {
            Product product = GetByKey(item.Id);
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
