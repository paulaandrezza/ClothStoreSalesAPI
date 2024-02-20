namespace Data.Models
{
    public class Sale
    {
        public static int _id = 1;

        public Sale(DateTime saleDate, string customerName, SaleItem[] items)
        {
            Id = _id++;
            SaleDate = saleDate;
            CustomerName = customerName;
            Items = items;
        }

        public int Id { get; set; }
        public DateTime SaleDate { get; set; }
        public string CustomerName { get; set; }
        public SaleItem[] Items { get; set; }
        public decimal TotalAmount => Items.Sum(item => item.Subtotal);
    }
}
