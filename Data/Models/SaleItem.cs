namespace Data.Models
{
    public class SaleItem
    {
        public SaleItem(int productId, string size, int quantity, decimal unitPrice)
        {
            ProductId = productId;
            Size = size.ToUpper();
            Quantity = quantity;
            UnitPrice = unitPrice;
        }

        public int ProductId { get; set; }
        public string Size { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal Subtotal => Quantity * UnitPrice;
    }
}
