using YungChingAPI.Models;

namespace YungChingAPI.Repositorys
{
    public class CategoryRepository(MasterContext _masterContext) : ICategoryRepository
    {
        public Category GetById(int categoryId)
        {
            try
            {
                return _masterContext.Categories.Find(categoryId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
