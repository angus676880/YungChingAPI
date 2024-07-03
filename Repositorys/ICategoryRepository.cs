using YungChingAPI.Models;

namespace YungChingAPI.Repositorys
{
    public interface ICategoryRepository
    {
        Category GetById(int categoryId);
    }
}
