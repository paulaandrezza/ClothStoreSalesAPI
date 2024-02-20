using Data.Models;
using Data.Models.Enums;
using Data.Repository.Interface;

namespace Data.Repository
{
    internal class ItemRepositoryInMemory : IItemRepository
    {
        private readonly List<Item> _items = new List<Item>();

        public ItemRepositoryInMemory(List<Item> items)
        {
            _items.Add(new Item("T-shirt", ItemType.Shirt, new string[] { "P", "M", "G" }, 29.99m));
            _items.Add(new Item("Jeans", ItemType.Pants, new string[] { "34", "36", "38", "40" }, 79.99m));
            _items.Add(new Item("Sneakers", ItemType.Shoes, new string[] { "36", "37", "38", "39", "40" }, 59.99m));
            _items.Add(new Item("Dress", ItemType.Dress, new string[] { "PP", "P", "M", "G", "GG" }, 89.99m));
        }

        public void Add(Item item)
        {
            _items.Add(item);
        }

        public void Delete(Item item)
        {
            _items.Remove(item);
        }

        public IEnumerable<Item> GetAll()
        {
            return _items;
        }

        public Item GetById(int id)
        {
            return _items.FirstOrDefault(i => i.Id == id);
        }

        public IEnumerable<Item> GetBySize(string size)
        {
            return _items.Where(i => i.Sizes.Contains(size));
        }

        public IEnumerable<Item> GetByType(ItemType type)
        {
            return _items.Where(i => i.Type == type);
        }

        public void Update(Item item)
        {
            var existingItem = _items.FirstOrDefault(i => i.Id == item.Id);
            if (existingItem != null)
            {
                existingItem.Name = item.Name;
                existingItem.Type = item.Type;
                existingItem.Sizes = item.Sizes;
                existingItem.Price = item.Price;
            }
        }
    }
}
