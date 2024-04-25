using ShoppingBLLibrary;
using ShoppingDALLibrary;
using ShoppingDALLibrary.Exceptions;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLTests
{
    public class CustomerBlTests
    {
        IRepository<int, Customer> _customerRespository;
        IRepository<int, Cart> _cartRespository;
        IRepository<int, Product> _productRespository;
        ICustomerService customerService;
        ICartService cartServices;
        IProductService productServices;
        [SetUp]
        public void Setup()
        {
            _cartRespository = new CartRepository();
            _customerRespository = new CustomerRepository();
            _productRespository = new ProductRepository();
            customerService = new CustomerBl(_customerRespository, _cartRespository);
            cartServices = new CartBl(_cartRespository, _productRespository);
            productServices = new ProductBl(_productRespository);
            //Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
        }
        [Test]
        public void AddCustomerSuccess()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            var customer = customerService.AddCustomer(cust1);
            Assert.AreEqual(customerService.GetCustomerById(1).Name, "Antony");
        }
        [Test]
        public void AddCustomerFailure()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            var firstcust = customerService.AddCustomer(cust1);
            var exception = Assert.Throws<DuplicateCustomerException>(() =>  customerService.AddCustomer(cust1));
            Assert.AreEqual(exception.Message, "This Customer Already Exists..");
        }
        [Test]  
        public void RemoveCustomerSuccess()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            Customer cust2 = new Customer() { Id = 2, Name = "Jeson", Age = 22, Phone = "90823450106" };
            var firstcust = customerService.AddCustomer(cust1);
            var seccust = customerService.AddCustomer(cust2);
            var deletedcust = customerService.DeleteCustomer(cust1);
            Assert.AreEqual(customerService.GetAllCustomers().Count, 1);
        }
        [Test]
        public void RemoveCustomerFailure()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            customerService.AddCustomer(cust1);
            var deletedcust = customerService.DeleteCustomer(cust1);
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerService.DeleteCustomer(cust1));
            Assert.AreEqual(exception.Message, "Customer with the given Id is not present");
        }
        [Test]
        public void GetAllCustomersFailure()
        {
            var exception = Assert.Throws<NoCustomerInException>(() => customerService.GetAllCustomers());
            Assert.AreEqual(exception.Message, "No Customer in the database add customer");
        }
        [Test]
        public void GetTotalOfCartWithDiscountSuccess()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            customerService.AddCustomer(cust1);
            Cart cart1 = new Cart()
            {
                Id = 1,
                CustomerId = 1,
                Customer = cust1,
                CartItems = new List<CartItem>()
            };
            cartServices.AddCart(cart1);
            Product PSprite = new Product()
            {
                Id = 1,
                Name = "Sprite Juice",
                Price = 35,
                Image = "Sprite Picture",
                QuantityInHand = 6
            };
            productServices.AddProduct(PSprite);
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05)
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            double total = customerService.GetCartTotalWithDiscount(1);
            Assert.IsNotNull(total);
        }
        [Test]
        public void GetTotalOfCartWithDiscountFailure()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            customerService.AddCustomer(cust1);
            Cart cart1 = new Cart()
            {
                Id = 1,
                CustomerId = 1,
                Customer = cust1,
                CartItems = new List<CartItem>()
            };
            cartServices.AddCart(cart1);
            Product PSprite = new Product()
            {
                Id = 1,
                Name = "Sprite Juice",
                Price = 35,
                Image = "Sprite Picture",
                QuantityInHand = 6
            };
            productServices.AddProduct(PSprite);
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05)
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerService.GetCartTotalWithDiscount(3));
        }
        [Test]
        public void GetCustomerByIdFailure()
        {
            var exception = Assert.Throws<NoCustomerWithGiveIdException>(() => customerService.GetCustomerById(1));
            Assert.AreEqual(exception.Message, "Customer with the given Id is not present");
        }
        [Test]
        public void GetAllCustomerCartItems()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            customerService.AddCustomer(cust1);
            Cart cart1 = new Cart()
            {
                Id = 1,
                CustomerId = 1,
                Customer = cust1,
                CartItems = new List<CartItem>()
            };
            cartServices.AddCart(cart1);
            Product PSprite = new Product()
            {
                Id = 1,
                Name = "Sprite Juice",
                Price = 35,
                Image = "Sprite Picture",
                QuantityInHand = 6
            };
            productServices.AddProduct(PSprite);
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05)
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            var result = customerService.GetCustomerCartItems(cust1.Id);
            Assert.AreEqual(result.Count, 1);
        }
        [Test]
        public void UpdateCustomerSuccess()
        {
            Customer cust1 = new Customer() { Id = 1, Name = "Antony", Age = 22, Phone = "9080950106" };
            customerService.AddCustomer(cust1);
            cust1.Age = 21;
            customerService.UpdateDetails(cust1);
            Assert.AreEqual(customerService.GetCustomerById(1).Age, 21);
        }
    }
}
