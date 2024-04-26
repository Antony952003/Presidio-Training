using ShoppingBLLibrary;
using ShoppingBLLibrary.Exceptions;
using ShoppingDALLibrary;
using ShoppingModelLibrary;
using ShoppingModelLibrary.Exceptions;

namespace ShoppingBLTests
{
    public class CartBlTests
    {
        IRepository<int, Cart> cartRepository;
        IRepository<int, Product> productRepository;
        ICartService cartServices;
        IProductService productServices;
        Product PSprite;
        Product PPepsi;
        Cart cart1;

        [SetUp]
        public void Setup()
        {
            cartRepository = new CartRepository();
            productRepository = new ProductRepository();
            cartServices = new CartBl(cartRepository,productRepository);
            productServices = new ProductBl(productRepository);
            Customer customer1 = new Customer()
            {
                Id = 1,
                Phone = "9080950106",
                Age = 23,
                Name = "Antony"
            };
            cart1 = new Cart()
            {
                Id = 1,
                CustomerId = 1,
                Customer = customer1,
                CartItems = new List<CartItem>()
            };
            cartServices.AddCart(cart1);
            PSprite = new Product()
            {
                Id = 1,
                Name = "Sprite Juice",
                Price = 35,
                Image = "Sprite Picture",
                QuantityInHand = 6,
                ProductStatus="Available"
            };
            PPepsi = new Product()
            {
                Id = 2,
                Name = "Pepsi Juice",
                Price = 30,
                Image = "Pepsi Picture",
                QuantityInHand = 6,
                ProductStatus = "Available"
            };
            productServices.AddProduct(PSprite);
            productServices.AddProduct(PPepsi);
        }
        [Test]
        public void AddCartItemSuccess()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024-09-05),
                CartItemstatus = PSprite.ProductStatus
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            Assert.AreEqual(productServices.GetAllProducts().Count, 2);
            Assert.AreEqual(cartServices.GetAllCartItems(cart1.Id).Count, 1);
        }
        [Test]
        public void AddCartItemFailure()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 7,
                PriceExpiryDate = new DateTime(2024 - 09 - 05),
                CartItemstatus = PSprite.ProductStatus
            };
            var exception = Assert.Throws<RequiredQuantityNotAvailableException>(() => cartServices.AddCartItem(cart1.Id, Sprite));
            Assert.AreEqual(exception.Message, "The Required amount of the item is not available...");
        }
        [Test]
        public void GetCartByIdSuccess()
        {
            var foundcart = cartServices.GetCartById(1);
            Assert.AreEqual(foundcart.Id, 1);
        }
        [Test]
        public void GetCartByIdFailure()
        {
            var exception = Assert.Throws<NoCartWithGiveIdException>(() => cartServices.GetCartById(2));
            Assert.AreEqual(exception.Message, "No cart for the given Id");
        }
        [Test]
        public void GetCartByCustomerIdSuccess()
        {
            var foundCart = cartServices.GetCartByCustomerID(1);
            Assert.AreEqual(foundCart.CustomerId, 1);
        }
        [Test]
        public void GetCartByCustomerIdFailure()
        {
            var exception = Assert.Throws<NoCartWithGiveIdException>(() => cartServices.GetCartByCustomerID(2));
            Assert.AreEqual(exception.Message, "No cart for the given Id");
        }

        [Test]
        public void RemoveItemSuccess()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05),
                CartItemstatus = PSprite.ProductStatus
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            Assert.AreEqual(cart1.CartItems.Count, 1);
            cartServices.RemoveItem(cart1.Id, Sprite);
            Assert.AreEqual(cart1.CartItems.Count, 0);
        }
        [Test]
        public void RemoveItemFailure()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05),
                CartItemstatus = PSprite.ProductStatus
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            Assert.AreEqual(cart1.CartItems.Count, 1);
            cartServices.RemoveItem(cart1.Id, Sprite);
            var exception = Assert.Throws<CartItemNotFoundException>(() => cartServices.RemoveItem(cart1.Id, Sprite));
            Assert.AreEqual(exception.Message, "The CartItem is not Found in the cart");
        }
        [Test]
        public void UpdateItemQuantitySuccess()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05),
                CartItemstatus = PSprite.ProductStatus
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            cartServices.UpdateQuantity(4, Sprite, cart1.Id);
            Assert.AreEqual(cartServices.GetCartItem(cart1.Id, Sprite.ProductId).Quantity, 4);
        }
        [Test]
        public void UpdateItemQuantityFailure()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05),
                CartItemstatus = PSprite.ProductStatus
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            var exception = Assert.Throws<MaximumQuantityExceededException>(() => cartServices.UpdateQuantity(7, Sprite, cart1.Id));
            Assert.AreEqual(exception.Message, "The Maximum Quantity for the Item has been exceeded it must be below 5");
        }
        [Test]
        public void ValidateCartItemsSuccess()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05),
                CartItemstatus = PSprite.ProductStatus
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            var isValid = cartServices.ValidateCart(cart1.CartItems);
            Assert.AreEqual(isValid, true);
        }
        [Test]
        public void ValidateCartItemsFailure()
        {
            var exception = Assert.Throws< NoItemsInCartException>(() => cartServices.ValidateCart(cart1.CartItems));
            Assert.AreEqual(exception.Message, "No Items in the Cart..");
            
        }
        [Test]
        public void TotalAmountforCartItems()
        {
            CartItem Sprite = new CartItem()
            {
                CartId = 1,
                Price = 35,
                ProductId = 1,
                Product = PSprite,
                Discount = 3,
                Quantity = 3,
                PriceExpiryDate = new DateTime(2024 - 09 - 05),
                CartItemstatus = PSprite.ProductStatus
            };
            cartServices.AddCartItem(cart1.Id, Sprite);
            double total = cartServices.TotalAmountForCartItems(cart1.Id);
            Assert.AreEqual(total, 105);
        }
    }
}