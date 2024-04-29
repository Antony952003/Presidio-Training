using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        Task<int> AddProduct(Product product);
        Task<Product> UpdateProduct(Product product);
        Task<Product> DeleteProduct(Product product);
        Task<Product> ChangeProductStatus(Product product,string status);
        Task<Product> GetProductById(int id);
        Task<Product> GetProductByName(string name);
        Task<List<Product>> GetAllProducts();
    }
    public interface ICustomerService
    {
        Task<int> AddCustomer(Customer customer);
        Task<Customer> GetCustomerById(int id);
        Task<List<CartItem>> GetCustomerCartItems(int Custid);
        Task<Customer> UpdateDetails(Customer customer);
        Task<Customer> DeleteCustomer(Customer customer);
        Task<double> GetCartTotalWithDiscount(int CustId);
        Task<List<Customer>> GetAllCustomers();
    }
    public interface ICartService
    {
        Task<int> AddCartItem(int cartId , CartItem cartItem);
        public Task<int> AddCart(Cart cart);
        Task<CartItem> RemoveItem(int cartid, CartItem cartItem);
        Task<Cart> GetCartById(int cartId);
        Task<Cart> GetCartByCustomerID(int customerId);
        Task<CartItem> UpdateQuantity(int quantity, CartItem cartItem, int cartid);
        Task<double> TotalAmountForCartItems(int cartId);
        Task<bool> ValidateCart(List<CartItem> cartitems);
        Task<List<CartItem>> GetAllCartItems(int cartId);
        Task<CartItem> GetCartItem(int cartId, int productId);
    }
}
