namespace Domain.Role.Exceptions;

public class NullNameException : Exception
{
    public override string Message => "Name was null";
}
