namespace Domain.Book.Exceptions
{
    public class InvalidBioException : Exception
    {
        public override string Message => "Invalid Bio input check for empty or null.";
    }
}
