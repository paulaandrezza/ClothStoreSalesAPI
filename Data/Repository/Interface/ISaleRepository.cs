using Data.Models;

namespace Data.Repository.Interface
{
    public interface ISaleRepository
    {
        void Add(Sale sale);
        Sale GetById(int id);
        IEnumerable<Sale> GetAll();
        void Delete(Sale sale);
    }
}
