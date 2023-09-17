namespace Domain.Book.Exceptions
{
    public class InvalidAuthorException : Exception
    {
        public override string Message => "Invalid Author input check for empty or null.";
    }
}
