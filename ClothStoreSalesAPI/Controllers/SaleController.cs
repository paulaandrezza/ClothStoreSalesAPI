using ClothStoreSalesAPI.RequestsModels;
using Data.Models;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothStoreSalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SaleController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IItemRepository _itemRepository;

        public SaleController(ISaleRepository saleRepository, IItemRepository itemRepository)
        {
            _saleRepository = saleRepository;
            _itemRepository = itemRepository;
        }

        /// <summary>
        /// Registers a new sale.
        /// </summary>
        /// <param name="saleRequest">The details of the sale.</param>
        /// <returns>A response indicating whether the sale was successfully registered.</returns>
        [HttpPost(Name = "AddSale")]
        public IActionResult AddSale([FromBody] CreateSaleRequest saleRequest)
        {
            foreach (var saleItem in saleRequest.SaleItems)
            {
                var item = _itemRepository.GetById(saleItem.ProductId);

                if (!item.Sizes.Contains(saleItem.Size.ToUpper()))
                {
                    return BadRequest($"Size {saleItem.Size} is not available for item with ID {saleItem.ProductId}.");
                }
            }

            Sale sale = new Sale(saleRequest.SaleDate, saleRequest.CustomerName, saleRequest.SaleItems);

            _saleRepository.Add(sale);
            return CreatedAtAction("GetSaleById", new { saleId = sale.Id }, new { message = "Resource created successfully.", data = sale });
        }

        /// <summary>
        /// Retrieves all sales.
        /// </summary>
        /// <returns>A list of all sales.</returns>
        [HttpGet(Name = "GetAllSales")]
        public IActionResult GetAllSales()
        {
            return Ok(_saleRepository.GetAll());
        }

        /// <summary>
        /// Retrieves a specific sale by its ID.
        /// </summary>
        /// <param name="saleId">The ID of the sale to retrieve.</param>
        /// <returns>The sale with the specified ID.</returns>
        [HttpGet("{saleId}", Name = "GetSaleById")]
        public IActionResult GetSaleById([FromRoute] int saleId)
        {
            Sale sale = _saleRepository.GetById(saleId);

            return Ok(sale);
        }
    }
}
