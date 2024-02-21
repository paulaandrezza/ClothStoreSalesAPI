namespace Data.CustomExceptions
{
    public class ClothStoreSalesApiException : Exception
    {
        public ClothStoreSalesApiException(string? message, int statusCode) : base(message)
        {
            StatusCode = statusCode;
        }

        public int StatusCode { get; }
    }
}
