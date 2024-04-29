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
        public async Task<int> AddCustomer(Customer customer)
        {
            try
            {
                Customer AddedCustomer = await _customerrepository.Add(customer);
                return AddedCustomer.Id;
            }
            catch (Exception ex)
            {
                throw;
            } 
        }

        public async Task<Customer> DeleteCustomer(Customer customer)
        {
            try
            {
                Customer foundcustomer = await _customerrepository.Delete(customer.Id);
                return foundcustomer;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        public async Task<List<Customer>> GetAllCustomers()
        {
            try
            {
                var result = await _customerrepository.GetAll();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<double> GetCartTotalWithDiscount(int CustId)
        {
            var listcarts = await _cartrepository.GetAll();
            Cart foundcart = listcarts.Find((cart) => cart.CustomerId == CustId);
            if (foundcart != null)
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

        public async Task<Customer> GetCustomerById(int id)
        {
            try
            {
                Customer foundCustomer = await _customerrepository.GetByKey(id);
                return foundCustomer;
            }
            catch(Exception ex)
            {
                throw;
            }

        }

        public async Task<List<CartItem>> GetCustomerCartItems(int Custid)
        {
            var listcarts = await _cartrepository.GetAll();
            Cart foundCart = listcarts.Find((cart) => cart.CustomerId == Custid);
            return foundCart.CartItems;
        }

        public async Task<Customer> UpdateDetails(Customer customer)
        {
            Customer foundCustomer = await _customerrepository.Update(customer);
            return customer;
        }
    }
}
