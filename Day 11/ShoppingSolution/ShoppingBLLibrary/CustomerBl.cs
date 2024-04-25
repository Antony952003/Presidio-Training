using ShoppingDALLibrary;
using ShoppingDALLibrary.Exceptions;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class CustomerBl : ICustomerService
    {
        IRepository<int, Customer> _customerrepository;
        IRepository<int, Cart> _cartrepository;
        public CustomerBl(IRepository<int, Customer> customerrepository, IRepository<int, Cart> cartrepository) { 
            _customerrepository = customerrepository;
            _cartrepository = cartrepository;
        }
        public int AddCustomer(Customer customer)
        {
            try
            {
                Customer AddedCustomer = _customerrepository.Add(customer);
                return AddedCustomer.Id;
            }
            catch (Exception ex)
            {
                throw;
            } 
        }

        public Customer DeleteCustomer(Customer customer)
        {
            try
            {
                Customer foundcustomer = _customerrepository.Delete(customer.Id);
                return foundcustomer;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public List<Customer> GetAllCustomers()
        {
            try
            {
                return _customerrepository.GetAll().ToList();
            }
            catch
            {
                throw;
            }
        }

        public double GetCartTotalWithDiscount(int CustId)
        {
            Cart foundcart = _cartrepository.GetAll().ToList().Find((cart) => cart.CustomerId == CustId);
            if(foundcart != null)
            {
                double total = 0;
                foreach (var cartItem in foundcart.CartItems) {
                    total += (cartItem.Quantity * cartItem.Price);
                }
                if (total < 100) return total + 100;
                if (total == 1500 && foundcart.CartItems.Count == 3) return total * 0.95;
                return total;
            }
            throw new NoCustomerWithGiveIdException();

        }

        public Customer GetCustomerById(int id)
        {
            try
            {
                Customer foundCustomer = _customerrepository.GetByKey(id);
                return foundCustomer;
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public List<CartItem> GetCustomerCartItems(int Custid)
        {
            var foundCart = _cartrepository.GetAll().ToList().Find((cart) => cart.CustomerId == Custid);
            return foundCart.CartItems;
        }

        public Customer UpdateDetails(Customer customer)
        {
            Customer foundCustomer = _customerrepository.Update(customer);
            return customer;
        }
    }
}
