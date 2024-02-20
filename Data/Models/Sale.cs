namespace Data.Models
{
    public class Sale
    {
        public static int _id = 1;

        public Sale(DateTime saleDate, string customerName, decimal totalAmount, SaleItem[] items)
        {
            Id = _id++;
            SaleDate = saleDate;
            CustomerName = customerName;
            TotalAmount = totalAmount;
            Items = items;
        }

        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public decimal TotalAmount { get; set; }
        public SaleItem[] Items { get; set; }
    }
}
