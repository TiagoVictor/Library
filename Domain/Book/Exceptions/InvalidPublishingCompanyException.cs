namespace Domain.Book.Exceptions
{
    public class InvalidPublishingCompanyException : Exception
    {
        public override string Message => "Invalid PublishingCompany input check for empty or null.";
    }
}
