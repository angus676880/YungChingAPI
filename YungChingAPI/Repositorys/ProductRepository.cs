using YungChingAPI.Models;
using YungChingAPI.Request;

namespace YungChingAPI.Repositorys
{
    public class ProductRepository(MasterContext _masterContext) : IProductRepository
    {
        public List<Product> GetAll()
        {
            try
            {
                return _masterContext.Products.ToList();
            }
            catch (Exception) {
                throw;
            }
        }
        public Product GetById(int productId)
        {
            try
            {
                return _masterContext.Products.Find(productId);
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int AddOne(Product product)
        {
            try
            {
                _masterContext.Products.Add(product);
                return _masterContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int UpdateOne(UpdateProductRequest data)
        {
            try
            {
                var productData = _masterContext.Products.Find(data.ProductId);
                productData.ProductName = data.ProductName;
                productData.SupplierId = data.SupplierId;
                productData.CategoryId = data.CategoryId;
                productData.QuantityPerUnit = data.QuantityPerUnit;
                productData.UnitPrice = data.UnitPrice;
                productData.UnitsInStock = data.UnitsInStock;
                productData.UnitsOnOrder = data.UnitsOnOrder;
                productData.ReorderLevel = data.ReorderLevel;
                productData.Discontinued = data.Discontinued;

                return _masterContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int DeleteOne(int productId)
        {
            try
            {
                var productData = _masterContext.Products.Find(productId);
                _masterContext.Products.Remove(productData);
                return _masterContext.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
