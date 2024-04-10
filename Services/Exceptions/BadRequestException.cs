namespace Services.Exceptions
{
    public class BadRequestException : Exception
    {
        public BadRequestException(string exception)
            : base(exception)
        {

        }
    }
}
