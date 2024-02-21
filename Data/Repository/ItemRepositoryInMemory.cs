using Data.CustomExceptions;
using Data.Models;
using Data.Models.Enums;
using Data.Repository.Interface;

namespace Data.Repository
{
    public class ItemRepositoryInMemory : IItemRepository
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

        public void Delete(int id)
        {
            Item item = GetById(id);
            _items.Remove(item);
        }

        public IEnumerable<Item> GetAll(string? size, ItemType? type)
        {
            IEnumerable<Item> items = _items;

            if (!string.IsNullOrEmpty(size))
            {
                items = items.Where(i => i.Sizes.Contains(size.ToUpper()));
            }

            if (type.HasValue)
            {
                items = items.Where(i => i.Type == type);
            }

            return items;
        }

        public Item GetById(int id)
        {
            Item item = _items.FirstOrDefault(i => i.Id == id);
            if (item == null)
                throw new ClothStoreSalesApiException($"The item with ID {id} was not found.", 404);
            return item;
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
