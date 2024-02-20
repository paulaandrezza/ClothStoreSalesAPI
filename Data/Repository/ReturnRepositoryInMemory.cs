using Data.Models;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class ReturnRepositoryInMemory : IReturnRepository
    {
        private readonly List<Return> _returns = new List<Return>();
        public void Add(Return returnSale)
        {
            _returns.Add(returnSale);
        }

        public IEnumerable<Return> GetAll()
        {
            return _returns;
        }

        public Return GetById(int id)
        {
            return _returns.FirstOrDefault(i => i.Id == id);
        }
    }
}
