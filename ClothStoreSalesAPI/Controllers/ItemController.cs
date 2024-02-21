using ClothStoreSalesAPI.RequestsModels;
using Data.Models;
using Data.Models.Enums;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Cors;
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

        /// <summary>
        /// Adds a new item to the store.
        /// </summary>
        /// <param name="itemRequest">The details of the item to be added.</param>
        /// <returns>A response indicating whether the item was successfully added.</returns>
        [HttpPost(Name = "AddItem")]
        public IActionResult AddItem([FromBody] CreateItemRequest itemRequest)
        {
            Item item = new Item(itemRequest.Name, itemRequest.Type, itemRequest.Sizes, itemRequest.Price);
            _itemRepository.Add(item);
            return CreatedAtAction("GetItemById", new { itemId = item.Id }, new { message = "Resource created successfully.", data = item });
        }

        /// <summary>
        /// Deletes an item from the store.
        /// </summary>
        /// <param name="itemId">The ID of the item to be deleted.</param>
        /// <returns>A response indicating whether the item was successfully deleted.</returns>
        [HttpDelete("{itemId}", Name = "DeleteItem")]
        public IActionResult DeleteItem([FromRoute] int itemId)
        {
            _itemRepository.Delete(itemId);
            return Ok("Item deleted sucesfully");
        }

        /// <summary>
        /// Retrieves all items from the store.
        /// </summary>
        /// <param name="size">Optional. The size of the items to filter by.</param>
        /// <param name="type">Optional. The type of the items to filter by.</param>
        /// <returns>A list of items filtered by the provided size and/or type.</returns>
        [EnableCors("localhost")]
        [HttpGet(Name = "GetAllItems")]
        public IActionResult GetAllItems([FromQuery] string? size = null, ItemType? type = null)
        {
            return Ok(_itemRepository.GetAll(size, type));
        }

        /// <summary>
        /// Retrieves a specific item from the store by its ID.
        /// </summary>
        /// <param name="itemId">The ID of the item to retrieve.</param>
        /// <returns>The item with the specified ID.</returns>
        [HttpGet("{itemId}", Name = "GetItemById")]
        public IActionResult GetItemById([FromRoute] int itemId)
        {
            return Ok(_itemRepository.GetById(itemId));
        }

        /// <summary>
        /// Updates the details of a specific item.
        /// </summary>
        /// <param name="itemId">The ID of the item to update.</param>
        /// <param name="itemRequest">The new details for the item.</param>
        /// <returns>A response indicating whether the item was successfully updated.</returns>
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
