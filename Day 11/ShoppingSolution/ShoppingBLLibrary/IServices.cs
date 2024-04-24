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
        List<CartItem> GetCustomerCarItems(int Custid);
        double GetCartTotalWithDiscount(int cartId, int CustId);
    }
    public interface ICartService
    {
        int AddCartItem(Cart cart , CartItem cartItem);
        CartItem RemoveItem(int cartid, CartItem cartItem);
        CartItem GetCartItem(int cartid, CartItem cartItem);
        CartItem UpdateQuantity(int quantity, CartItem cartItem, int cartid);
        double TotalAmountForCartItems(List<Product> products);
        bool ValidateCart(List<CartItem> cartitems);
    }
}
