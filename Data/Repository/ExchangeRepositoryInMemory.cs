using Data.Models;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class ExchangeRepositoryInMemory : IExchangeRepository
    {
        private readonly List<Exchange> _exchange = new List<Exchange>();

        public void Add(Exchange exchangeSale)
        {
            _exchange.Add(exchangeSale);
        }

        public IEnumerable<Exchange> GetAll()
        {
            return _exchange;
        }

        public Exchange GetById(int id)
        {
            return _exchange.FirstOrDefault(i => i.Id == id);
        }
    }
}
