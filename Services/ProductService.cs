using YungChingAPI.Models;
using YungChingAPI.Repositorys;
using YungChingAPI.Request;
using YungChingAPI.Utils;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace YungChingAPI.Services
{
    public class ProductService
        (
            IProductRepository _productRepository,
            ICategoryRepository _categoryRepository,
            ISupplierRepository _supplierRepository
        ) : IProductService
    {
        public List<Product> GetAll()
        {
            try
            {
                return _productRepository.GetAll();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public Product GetById(int productId)
        {
            try
            {
                var productData = _productRepository.GetById(productId);
                if (productData == null)
                {
                    throw new MyException("2001", $"No product found with ID '{productId}'.");
                }
                return _productRepository.GetById(productId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void AddProduct(AddProductRequest data)
        {
            try
            {
                var categoryData = _categoryRepository.GetById(data.CategoryId);
                if (categoryData == null)
                {
                    throw new MyException("2002", $"No Category found with ID '{data.CategoryId}'.");
                }
                var supplierData = _supplierRepository.GetById(data.SupplierId);
                if (supplierData == null)
                {
                    throw new MyException("2002", $"No Supplier found with ID '{data.SupplierId}'.");
                }

                var insertData = new Product
                {
                    ProductName = data.ProductName,
                    SupplierId = data.SupplierId,
                    CategoryId = data.CategoryId,
                    QuantityPerUnit = data.QuantityPerUnit,
                    UnitPrice = data.UnitPrice,
                    UnitsInStock = data.UnitsInStock,
                    UnitsOnOrder = data.UnitsOnOrder,
                    ReorderLevel = data.ReorderLevel,
                    Discontinued = data.Discontinued,
                };
                var insertResult = _productRepository.AddOne(insertData);
                if (insertResult == 0)
                {
                    throw new MyException("9001", $"Insert Failed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void UpdateProduct(UpdateProductRequest data)
        {
            try
            {
                var productData = _productRepository.GetById(data.ProductId);
                if (productData == null)
                {
                    throw new MyException("2001", $"No product found with ID '{data.ProductId}'.");
                }
                var categoryData = _categoryRepository.GetById(data.CategoryId);
                if (categoryData == null)
                {
                    throw new MyException("2002", $"No Category found with ID '{data.CategoryId}'.");
                }
                var supplierData = _supplierRepository.GetById(data.SupplierId);
                if (supplierData == null)
                {
                    throw new MyException("2002", $"No Supplier found with ID '{data.SupplierId}'.");
                }
                var updateResult = _productRepository.UpdateOne(data);
                if (updateResult == 0)
                {
                    throw new MyException("9002", $"Update Failed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
        public void DeleteProduct(int productId)
        {
            try
            {
                var productData = _productRepository.GetById(productId);
                if (productData == null)
                {
                    throw new MyException("2001", $"No product found with ID '{productId}'.");
                }
                var deleteResult = _productRepository.DeleteOne(productId);
                if (deleteResult == 0)
                {
                    throw new MyException("9003", $"Delete Failed");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
