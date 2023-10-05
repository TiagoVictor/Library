namespace Domain.User.Exceptions;

public class NullPasswordHashException : Exception
{
    public override string Message => "Password Hash was null";
}
