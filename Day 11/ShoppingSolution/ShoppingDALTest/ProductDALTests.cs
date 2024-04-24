using ShoppingDALLibrary;
using ShoppingModelLibrary.Exceptions;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALTest
{
    public class ProductDALTests
    {
        IRepository<int, Product> productRepository;


        [SetUp]
        public void Setup()
        {
            productRepository = new ProductRepository();
        }

        [Test]
        public void ProductAddSuccessTest()
        {
            Product product = new Product { Id = 1, Price = 100, Name = "Product1", Image = "dummy", QuantityInHand = 10 };
            productRepository.Add(product);
            Product foundProduct = productRepository.GetByKey(1);
            var result = productRepository.GetAll();
            Assert.That(foundProduct, Is.EqualTo(product));
            Assert.That(result.Count, Is.EqualTo(1));
        }

        [Test]
        public void ProductUpdateSuccessTest()
        {
            Product product = new Product { Id = 1, Price = 100, Name = "Product1", Image = "dummy1", QuantityInHand = 10 };
            productRepository.Add(product);

            Product foundProduct = new Product { Id = 1, Price = 200, Name = "Product2", Image = "dummy2", QuantityInHand = 20 };
            productRepository.Update(foundProduct);

            Product product2 = productRepository.GetByKey(1);
            Assert.That(product2.Name, Is.EqualTo("Product2"));
        }

        [Test]
        public void ProductDeleteSuccessTest()
        {
            Product product = new Product { Id = 1, Price = 100, Name = "Product1", Image = "dummy1", QuantityInHand = 10 };
            productRepository.Add(product);
            productRepository.Delete(1);
            var result = productRepository.GetAll();
            Assert.That(result.Count, Is.EqualTo(0));
        }

        [Test]
        public void ProductGetByKeySuccessTest()
        {
            Product product = new Product { Id = 1, Price = 100, Name = "Product1", Image = "dummy1", QuantityInHand = 10 };
            productRepository.Add(product);
            Product foundProduct = productRepository.GetByKey(1);
            Assert.That(foundProduct, Is.EqualTo(product));
        }

        [Test]
        public void ProductGetAllSuccessTest()
        {
            Product product = new Product { Id = 1, Price = 100, Name = "Product1", Image = "dummy1", QuantityInHand = 10 };
            productRepository.Add(product);
            Product foundProduct = new Product { Id = 2, Price = 200, Name = "Product2", Image = "dummy2", QuantityInHand = 20 };
            productRepository.Add(foundProduct);
            var result = productRepository.GetAll();
            Assert.That(result.Count, Is.EqualTo(2));
        }

        [Test]
        public void ProductGetByKeyFailureTest()
        {
            Product product = new Product { Id = 1, Price = 100, Name = "Product1", Image = "dummy1", QuantityInHand = 10 };
            productRepository.Add(product);
            Assert.Throws<NoProductWithGivenIdException>(() => productRepository.GetByKey(2));
        }
    }
}
