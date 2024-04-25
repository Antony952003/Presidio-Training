using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public interface IProductService
    {
        int AddProduct(Product product);
        Product UpdateProduct(Product product);
        Product DeleteProduct(Product product);
        Product GetProductById(int id);
        Product GetProductByName(string name);
        List<Product> GetAllProducts();
    }
    public interface ICustomerService
    {
        int AddCustomer(Customer customer);
        Customer GetCustomerById(int id);
        List<CartItem> GetCustomerCartItems(int Custid);
        Customer UpdateDetails(Customer customer);
        Customer DeleteCustomer(Customer customer);
        double GetCartTotalWithDiscount(int CustId);
        List<Customer> GetAllCustomers();
    }
    public interface ICartService
    {
        int AddCartItem(int cartId , CartItem cartItem);
        public int AddCart(Cart cart);
        CartItem RemoveItem(int cartid, CartItem cartItem);
        Cart GetCartById(int cartId);
        Cart GetCartByCustomerID(int customerId);
        CartItem UpdateQuantity(int quantity, CartItem cartItem, int cartid);
        double TotalAmountForCartItems(int cartId);
        bool ValidateCart(List<CartItem> cartitems);
        List<CartItem> GetAllCartItems(int cartId);
        CartItem GetCartItem(int cartId, int productId);
    }
}
