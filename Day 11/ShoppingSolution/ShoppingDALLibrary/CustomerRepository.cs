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
    public class CustomerRepository : AbstractRepository<int, Customer>
    {

        public override Customer Add(Customer item)
        {
            if (!items.Contains(item)) { 
                items.Add(item);
                return item;
            }
            throw new DuplicateCustomerException();
                
        }
        public override Customer Delete(int key)
        {
            Customer customer = GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }
        public override List<Customer> GetAll()
        {
            if(items.Count == 0)    throw new NoCustomerInException();
            return items.ToList();
        }

        public override Customer GetByKey(int key)
        {
            for (int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == key)
                    return items[i];
            }
            throw new NoCustomerWithGiveIdException();
        }

        public override Customer Update(Customer item)
        {
            for(int i = 0; i < items.Count; i++)
            {
                if (items[i].Id == item.Id)
                {
                    items[i] = item;
                    return item;
                }
            }
            throw new NoCustomerWithGiveIdException();
        }
    }
}
