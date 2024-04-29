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

        public override async Task<Customer> Add(Customer item)
        {
            if (!items.Contains(item)) { 
                items.Add(item);
                return item;
            }
            throw new DuplicateCustomerException();
                
        }
        public override async Task<Customer> Delete(int key)
        {
            Customer customer = await GetByKey(key);
            if (customer != null)
            {
                items.Remove(customer);
            }
            return customer;
        }
        public override async Task<List<Customer>> GetAll()
        {
            if(items.Count == 0)    throw new NoCustomerInException();
            return items;
        }

        public override async Task<Customer> GetByKey(int key)
        {
            try
            {
                Customer foundcustomer = items.Find((customer) => customer.Id == key);
                return foundcustomer;
            }
            catch
            {
                throw new NoCustomerWithGiveIdException();
            }
        }

        public override async Task<Customer> Update(Customer item)
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
