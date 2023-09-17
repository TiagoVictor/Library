namespace Domain.Book.Exceptions
{
    public class InvalidEditionException : Exception
    {
        public override string Message => "Invalid Edition input check for zero or less edition.";
    }
}
