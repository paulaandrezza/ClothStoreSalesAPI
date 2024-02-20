using Data.Models;

namespace Data.Repository.Interface
{
    internal interface ISaleRepository
    {
        void Add(Sale sale);
        void Update(Sale sale);
        void Delete(Sale sale);
        Sale GetById(int id);
        IEnumerable<Sale> GetAll();
    }
}
