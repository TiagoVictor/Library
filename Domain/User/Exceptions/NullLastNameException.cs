namespace Domain.User.Exceptions;

public class NullLastNameException : Exception
{
    public override string Message => "Last Name was null";
}
