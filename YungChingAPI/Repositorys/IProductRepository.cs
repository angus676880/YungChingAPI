using YungChingAPI.Models;
using YungChingAPI.Request;

namespace YungChingAPI.Repositorys
{
    public interface IProductRepository
    {
        List<Product> GetAll();
        Product GetById(int productId);
        int AddOne(Product product);
        int UpdateOne(UpdateProductRequest data);
        int DeleteOne(int productId);
    }
}
