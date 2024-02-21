using Data.Models;
using Data.Models.Enums;

namespace Data.Repository.Interface
{
    public interface IItemRepository
    {
        void Add(Item item);
        void Update(Item item);
        void Delete(int id);
        Item GetById(int id);
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetByType(ItemType type);
        IEnumerable<Item> GetBySize(string size);
    }
}
