using Data.Models;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class SaleRepositoryInMemory : ISaleRepository
    {
        private readonly List<Sale> _sales = new List<Sale>();

        public void Add(Sale sale)
        {
            _sales.Add(sale);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _sales;
        }

        public Sale GetById(int id)
        {
            return _sales.FirstOrDefault(s => s.Id == id);
        }
    }
}
