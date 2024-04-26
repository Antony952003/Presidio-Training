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
using System.Xml.Serialization;

namespace ShoppingBLTests
{
    public  class ProductBLTests
    {
        IRepository<int, Product> productrepository;
        IProductService productService;
        Product prod1;
        Product prod2;
        [SetUp]
        public void SetUp()
        {
            productrepository = new ProductRepository();
            productService = new ProductBl(productrepository);
            prod1 = new Product()
            {
                Id = 1,
                Name= "Pepsi",
                Price= 35,
                Image="Pepsi Image",
                ProductStatus="Available",
                QuantityInHand=5
                
            };
            prod2 = new Product()
            {
                Id = 2,
                Name = "Sprite",
                Price = 32,
                Image = "Sprite Image",
                ProductStatus = "Available",
                QuantityInHand = 4
            };
        }
        [Test]
        public void AddProductSuccess()
        {
            var AddedProduct = productService.AddProduct(prod1);
            Assert.AreEqual(productService.GetAllProducts().Count, 1);
        }
        [Test]
        public void AddProductFail()
        {
            var AddedProduct1 = productService.AddProduct(prod1);
            var exception = Assert.Throws<DuplicateProductException>(() => productService.AddProduct(prod1));
            Assert.AreEqual(exception.Message, "This Product Already Exists..");
        }
        [Test]

        public void DeleteProductSuccess()
        {
            var AddedProduct = productService.AddProduct(prod1);
            var AddedProduct2 = productService.AddProduct(prod2);
            var deletedProduct = productService.DeleteProduct(prod1);
            Assert.AreEqual(productService.GetAllProducts().Count, 1);
        }

        [Test]
        public void DeleteProductFail()
        {
            var AddedProduct = productService.AddProduct(prod1);
            var deletedProduct = productService.DeleteProduct(prod1);
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => productService.DeleteProduct(prod1));
            Assert.AreEqual(exception.Message, "Product with the given Id is not present");
        }
        [Test]
        public void UpdateProductSuccess()
        {
            var AddedProductId = productService.AddProduct(prod1);
            var addedproduct = productService.GetProductById(AddedProductId);
            addedproduct.Name = "Coke";
            productService.UpdateProduct(addedproduct);
        }
        [Test]
        public void UpdateProductFail()
        {
            var exception = Assert.Throws<NoProductWithGivenIdException>(() => productService.GetProductById(prod1.Id));
            Assert.AreEqual(exception.Message, "Product with the given Id is not present");
        }
    }
}
