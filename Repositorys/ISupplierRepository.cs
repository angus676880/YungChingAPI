using YungChingAPI.Models;

namespace YungChingAPI.Repositorys
{
    public interface ISupplierRepository
    {
        Supplier GetById(int supplierId);
    }
}
