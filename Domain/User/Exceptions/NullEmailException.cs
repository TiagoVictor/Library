namespace Domain.User.Exceptions;

public class NullEmailException : Exception
{
    public override string Message => "Email was null";
}
