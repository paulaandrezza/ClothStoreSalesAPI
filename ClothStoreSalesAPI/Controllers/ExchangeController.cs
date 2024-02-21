using ClothStoreSalesAPI.RequestsModels;
using Data.Models;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothStoreSalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ExchangeController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IExchangeRepository _exchangeRepository;

        public ExchangeController(ISaleRepository saleRepository, IExchangeRepository exchangeRepository)
        {
            _saleRepository = saleRepository;
            _exchangeRepository = exchangeRepository;
        }

        [HttpPost("{saleId}", Name = "AddExchange")]
        public IActionResult AddExchange([FromRoute] int saleId, [FromBody] CreateReturnAndExchangeRequest exchangeRequest)
        {
            Sale sale = _saleRepository.GetById(saleId);
            if (sale == null)
                return NotFound($"The sale with ID {saleId} was not found.");

            DateTime finalExchangeDate = sale.SaleDate.AddDays(7);

            if (exchangeRequest.Date > finalExchangeDate)
                return BadRequest($"Exchanges are allowed only within 7 business days after the sale date.");

            Exchange exchangeSale = new Exchange(exchangeRequest.Date, sale);

            _exchangeRepository.Add(exchangeSale);
            _saleRepository.Delete(sale);

            return Ok(new { Message = "Exchange registered successfully." });
        }

        [HttpGet(Name = "GetAllExchanges")]
        public IActionResult GetAllExchanges()
        {
            return Ok(_exchangeRepository.GetAll());
        }
    }
}
