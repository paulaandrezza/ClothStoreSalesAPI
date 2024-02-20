using Data.Models.Enums;

namespace Data.Models
{
    public class Item
    {
        private static int _id = 1;

        public Item(string name, ItemType type, string[] sizes, decimal price)
        {
            Id = _id++;
            Name = name;
            Type = type;
            Sizes = sizes;
            Price = price;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public ItemType Type { get; set; }
        public string[] Sizes { get; set; }
        public decimal Price { get; set; }
    }
}
