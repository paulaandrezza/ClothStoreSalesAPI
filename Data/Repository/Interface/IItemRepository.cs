using Data.Models;
using Data.Models.Enums;

namespace Data.Repository.Interface
{
    internal interface IItemRepository
    {
        void Add(Item item);
        void Update(Item item);
        void Delete(Item item);
        Item GetById(int id);
        IEnumerable<Item> GetAll();
        IEnumerable<Item> GetByType(ItemType type);
        IEnumerable<Item> GetBySize(string size);
    }
}
