namespace Domain.Book.Exceptions
{
    public class InvalidPagesException : Exception
    {
        public override string Message => "Invalid Pages input check for zero or less pages.";
    }
}
