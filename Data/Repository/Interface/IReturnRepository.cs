using Data.Models;

namespace Data.Repository.Interface
{
    public interface IReturnRepository
    {
        void Add(Return returnSale);
        IEnumerable<Return> GetAll();
        Return GetById(int id);
    }
}
