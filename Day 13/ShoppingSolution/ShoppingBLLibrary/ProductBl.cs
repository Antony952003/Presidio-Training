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
        public async Task<int> AddProduct(Product product)
        {
            try
            {
                var addedProduct = await _productrepository.Add(product);
                return addedProduct.Id;
            }
            catch(Exception ex)
            {
                throw;
            }
        }
        public async Task<Product> ChangeProductStatus(Product product, string status)
        {
            try
            {
                var foundproduct = await _productrepository.GetByKey(product.Id);
                foundproduct.ProductStatus = status;
                _productrepository.Update(foundproduct);
                return foundproduct;
            }
            catch
            {
                throw;
            }
        }

        public async Task<Product> DeleteProduct(Product product)
        {
            var deletedProduct = await _productrepository.Delete(product.Id);
            return deletedProduct;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            var allproducts = await _productrepository.GetAll();
            return allproducts.FindAll((p) => p.ProductStatus.Equals("Available"));
        }

        public async Task<Product> GetProductById(int id)
        {
            try
            {
                var foundProduct = await _productrepository.GetByKey(id);
                return foundProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> GetProductByName(string name)
        {
            try
            {
                var allproducts = await _productrepository.GetAll();
                var foundProduct = allproducts.Find((product) => product.Name == name);
                return foundProduct;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Product> UpdateProduct(Product product)
        {
            var UpdatedProduct = await _productrepository.Update(product);
            return UpdatedProduct;
        }
    }
}
