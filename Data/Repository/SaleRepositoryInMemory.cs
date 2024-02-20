using Data.Models;
using Data.Repository.Interface;

namespace Data.Repository
{
    internal class SaleRepositoryInMemory : ISaleRepository
    {
        private readonly List<Sale> _sales = new List<Sale>();

        public void Add(Sale sale)
        {
            _sales.Add(sale);
        }

        public void Delete(Sale sale)
        {
            _sales.Remove(sale);
        }

        public IEnumerable<Sale> GetAll()
        {
            return _sales;
        }

        public Sale GetById(int id)
        {
            return _sales.FirstOrDefault(s => s.Id == id);
        }

        public void Update(Sale sale)
        {
            var existingSale = GetById(sale.Id);
            if (existingSale != null)
            {
                existingSale.CustomerName = sale.CustomerName;
                existingSale.Items = sale.Items;
                existingSale.TotalAmount = sale.TotalAmount;
                existingSale.SaleDate = sale.SaleDate;
            }
        }
    }
}
