using Data.Models;

namespace Data.Repository.Interface
{
    public interface ISaleItemRepository
    {
        void Add(SaleItem saleItem);
        void Update(SaleItem saleItem);
        void Delete(int id);
        SaleItem GetById(int id);
        IEnumerable<SaleItem> GetAll();
        IEnumerable<SaleItem> GetBySaleId(int saleId);
    }
}
