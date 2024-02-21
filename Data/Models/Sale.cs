namespace Data.Models
{
    public class Sale
    {
        public static int _id = 1;

        public Sale(DateTime saleDate, string customerName, SaleItem[] saleItems)
        {
            Id = _id++;
            SaleDate = saleDate;
            CustomerName = customerName;
            SaleItems = saleItems;
        }

        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public SaleItem[] SaleItems { get; set; }
        public decimal TotalAmount => SaleItems.Sum(item => item.Subtotal);
    }
}
