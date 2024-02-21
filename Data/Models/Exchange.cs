namespace Data.Models
{
    public class Exchange
    {
        public static int _id = 1;

        public Exchange(DateTime exchangeDate, Sale sale)
        {
            Id = _id++;
            ExchangeDate = exchangeDate;
            Sale = sale;
        }

        public int Id { get; set; }
        public DateTime ExchangeDate { get; set; }
        public Sale Sale { get; set; }
    }
}
