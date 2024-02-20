using System.ComponentModel.DataAnnotations;

namespace ClothStoreSalesAPI.RequestsModels
{
    public class CreateReturnRequest
    {
        [Required]
        public DateTime ReturnDate { get; set; }
        [Required]
        public int SaleId { get; set; }
    }
}