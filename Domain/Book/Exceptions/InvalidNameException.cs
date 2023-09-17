namespace Domain.Book.Exceptions
{
    public class InvalidNameException : Exception
    {
        public override string Message => "Invalid Name input check for empty or null.";
    }
}
