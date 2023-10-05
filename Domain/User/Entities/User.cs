using Domain.User.Exceptions;
using Domain.User.Ports;
using RoleEntity = Domain.Role.Entities;

namespace Domain.User.Entities;
public class User
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }

    public IList<RoleEntity.Role> Roles { get; set; }

    private void ValidateState()
    {
        if (string.IsNullOrEmpty(Email))
            throw new NullNameException();

        if (string.IsNullOrEmpty(LastName))
            throw new NullLastNameException();

        if (string.IsNullOrEmpty(Email))
            throw new NullEmailException();

        if (string.IsNullOrEmpty(PasswordHash))
            throw new NullPasswordHashException();
    }

    public async Task Save(IUserRepository repository)
    {
        ValidateState();

        if (Id == 0)
            Id = await repository.CreateAsync(this);
        else
            await repository.UpdateUser(this);
    }
}
