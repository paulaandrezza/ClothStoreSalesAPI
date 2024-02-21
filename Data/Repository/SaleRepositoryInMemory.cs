using Data.CustomExceptions;
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
            Sale sale = _sales.FirstOrDefault(s => s.Id == id);
            if (sale == null)
                throw new ClothStoreSalesApiException($"The sale with ID {id} was not found.", 404);

            return sale;
        }
    }
}
