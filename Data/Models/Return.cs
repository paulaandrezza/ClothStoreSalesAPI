namespace Data.Models
{
    public class Return
    {
        public static int _id = 1;

        public Return(DateTime returnDate, Sale sale)
        {
            Id = _id++;
            ReturnDate = returnDate;
            Sale = sale;
        }

        public int Id { get; set; }
        public DateTime ReturnDate { get; set; }
        public Sale Sale { get; set; }
    }
}
