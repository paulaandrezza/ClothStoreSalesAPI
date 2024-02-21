using ClothStoreSalesAPI.RequestsModels;
using Data.Models;
using Data.Repository.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ClothStoreSalesAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReturnController : ControllerBase
    {
        private readonly ISaleRepository _saleRepository;
        private readonly IReturnRepository _returnRepository;

        public ReturnController(ISaleRepository saleRepository, IReturnRepository returnRepository)
        {
            _saleRepository = saleRepository;
            _returnRepository = returnRepository;
        }

        [HttpPost("{saleId}", Name = "AddReturn")]
        public IActionResult AddReturn([FromRoute] int saleId, [FromBody] CreateReturnAndExchangeRequest returnRequest)
        {
            Sale sale = _saleRepository.GetById(saleId);
            if (sale == null)
                return NotFound($"The sale with ID {saleId} was not found.");

            Return returnSale = new Return(returnRequest.Date, sale);

            _returnRepository.Add(returnSale);
            _saleRepository.Delete(sale);

            return Ok(new { Message = "Return registered successfully." });
        }

        [HttpGet(Name = "GetAllReturns")]
        public IActionResult GetAllReturns()
        {
            return Ok(_returnRepository.GetAll());
        }
    }
}
