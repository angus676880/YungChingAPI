using YungChingAPI.Models;
using YungChingAPI.Request;

namespace YungChingAPI.Services
{
    public interface IProductService
    {
        List<Product> GetAll();
        Product GetById(int productId);
        void AddProduct(AddProductRequest product);
        void UpdateProduct(UpdateProductRequest product);
        void DeleteProduct(int productId);
    }
}
