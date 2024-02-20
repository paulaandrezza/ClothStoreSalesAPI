using Data.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace ClothStoreSalesAPI.RequestsModels
{
    public class CreateItemRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public ItemType Type { get; set; }
        [Required]
        public string[] Sizes { get; set; }
        [Required]
        public decimal Price { get; set; }
    }
}
