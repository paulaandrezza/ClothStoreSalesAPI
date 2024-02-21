using Data.CustomExceptions;
using Data.Models;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class ExchangeRepositoryInMemory : IExchangeRepository
    {
        private readonly List<Exchange> _exchange = new List<Exchange>();

        public void Add(Sale sale, Exchange exchangeSale)
        {
            DateTime finalExchangeDate = sale.SaleDate.AddDays(7);
            if (exchangeSale.ExchangeDate > finalExchangeDate)
                throw new ClothStoreSalesApiException("Exchanges are allowed only within 7 business days after the sale date.", 500);

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
