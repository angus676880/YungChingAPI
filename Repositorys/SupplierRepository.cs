using YungChingAPI.Models;

namespace YungChingAPI.Repositorys
{
    public class SupplierRepository(MasterContext _masterContext) : ISupplierRepository
    {
        public Supplier GetById(int supplierId)
        {
            try
            {
                return _masterContext.Suppliers.Find(supplierId);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
