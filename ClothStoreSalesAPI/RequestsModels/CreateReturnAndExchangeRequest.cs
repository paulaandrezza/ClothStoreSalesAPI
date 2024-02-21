using System.ComponentModel.DataAnnotations;

namespace ClothStoreSalesAPI.RequestsModels
{
    public class CreateReturnAndExchangeRequest
    {
        [Required]
        public DateTime Date { get; set; }
    }
}