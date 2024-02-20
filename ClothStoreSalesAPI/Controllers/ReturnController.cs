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

        [HttpPost(Name = "AddReturn")]
        public IActionResult AddReturn([FromBody] CreateReturnRequest returnRequest)
        {
            Sale sale = _saleRepository.GetById(returnRequest.SaleId);
            if (sale == null)
                return NotFound($"The sale with ID {returnRequest.SaleId} was not found.");

            Return returnSale = new Return(returnRequest.ReturnDate, sale);

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
