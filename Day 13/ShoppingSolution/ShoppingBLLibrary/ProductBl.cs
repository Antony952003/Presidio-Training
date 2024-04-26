using ShoppingDALLibrary;
using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingBLLibrary
{
    public class ProductBl : IProductService
    {
        IRepository<int, Product> _productrepository;
        public ProductBl(IRepository<int, Product> productrepository)
        {
            _productrepository = productrepository;
        }
        public int AddProduct(Product product)
        {
            try
            {
                var addedProduct = _productrepository.Add(product);
                return addedProduct.Id;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public Product ChangeProductStatus(Product product, string status)
        {
            try
            {
                var foundproduct = _productrepository.GetByKey(product.Id);
                foundproduct.ProductStatus = status;
                _productrepository.Update(foundproduct);
                return foundproduct;
            }
            catch
            {
                throw;
            }
        }

        public Product DeleteProduct(Product product)
        {
            var deletedProduct = _productrepository.Delete(product.Id);
            return deletedProduct;
        }

        public List<Product> GetAllProducts()
        {
            return _productrepository.GetAll().ToList().FindAll((p) => p.ProductStatus.Equals("Available"));
        }

        public Product GetProductById(int id)
        {
            try
            {
                var foundProduct = _productrepository.GetByKey(id);
                return foundProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product GetProductByName(string name)
        {
            try
            {
                var foundProduct = _productrepository.GetAll().ToList().Find((product) => product.Name == name);
                return foundProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public Product UpdateProduct(Product product)
        {
            var UpdatedProduct = _productrepository.Update(product);
            return UpdatedProduct;
        }
    }
}
