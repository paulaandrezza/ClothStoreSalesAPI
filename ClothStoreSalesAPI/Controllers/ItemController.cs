using ClothStoreSalesAPI.RequestsModels;
using Data.Models;
using Data.Models.Enums;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothStoreSalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ItemController : ControllerBase
    {
        private readonly IItemRepository _itemRepository;

        public ItemController(IItemRepository itemRepository)
        {
            _itemRepository = itemRepository;
        }

        [HttpPost(Name = "AddItem")]
        public IActionResult AddItem([FromBody] CreateItemRequest itemRequest)
        {
            Item item = new Item(itemRequest.Name, itemRequest.Type, itemRequest.Sizes, itemRequest.Price);
            _itemRepository.Add(item);
            return Ok(new { Message = "Created successfully" });
        }

        [HttpDelete("{itemId}", Name = "DeleteItem")]
        public IActionResult DeleteItem([FromRoute] int itemId)
        {
            _itemRepository.Delete(itemId);
            return Ok("Item deleted sucesfully");
        }

        [HttpGet(Name = "GetAllItems")]
        public IActionResult GetAllItems([FromQuery] string? size = null, ItemType? type = null)
        {
            if (size != null)
                return Ok(_itemRepository.GetBySize(size));
            else if (type != null)
                return Ok(_itemRepository.GetByType((ItemType)type));
            return Ok(_itemRepository.GetAll());
        }

        [HttpGet("{itemId}", Name = "GetItemById")]
        public IActionResult GetItemById([FromRoute] int itemId)
        {
            return Ok(_itemRepository.GetById(itemId));
        }

        [HttpPut("{itemId}", Name = "UpdateItem")]
        public IActionResult UpdateItem([FromRoute] int itemId, CreateItemRequest itemRequest)
        {
            Item item = _itemRepository.GetById(itemId);

            item.Name = itemRequest.Name;
            item.Type = itemRequest.Type;
            item.Sizes = itemRequest.Sizes;
            item.Price = itemRequest.Price;

            _itemRepository.Update(item);
            return Ok(new { Message = "Item updated successfully." });
        }
    }
}
