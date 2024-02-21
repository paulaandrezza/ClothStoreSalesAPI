using Data.Models;

namespace Data.Repository.Interface
{
    public interface IExchangeRepository
    {
        void Add(Exchange exchangeSale);
        IEnumerable<Exchange> GetAll();
        Exchange GetById(int id);
    }
}
