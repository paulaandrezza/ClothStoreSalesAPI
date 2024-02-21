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

        /// <summary>
        /// Registers a return for a sale.
        /// </summary>
        /// <param name="saleId">The ID of the sale for which the return is being registered.</param>
        /// <param name="returnRequest">The details of the return.</param>
        /// <returns>A response indicating whether the return was successfully registered.</returns>
        [HttpPost("{saleId}", Name = "AddReturn")]
        public IActionResult AddReturn([FromRoute] int saleId, [FromBody] CreateReturnAndExchangeRequest returnRequest)
        {
            Sale sale = _saleRepository.GetById(saleId);

            Return returnSale = new Return(returnRequest.Date, sale);

            _returnRepository.Add(returnSale);
            _saleRepository.Delete(sale);

            return Ok(new { Message = "Return registered successfully." });
        }

        /// <summary>
        /// Retrieves all returns.
        /// </summary>
        /// <returns>A list of all returns.</returns>
        [HttpGet(Name = "GetAllReturns")]
        public IActionResult GetAllReturns()
        {
            return Ok(_returnRepository.GetAll());
        }
    }
}
