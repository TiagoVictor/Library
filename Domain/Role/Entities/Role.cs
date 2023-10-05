using Domain.Role.Exceptions;
using Domain.Role.Ports;
using UserEntity = Domain.User.Entities;

namespace Domain.Role.Entities;

public class Role
{
    public int Id { get; set; }
    public string Name { get; set; }

    public IList<UserEntity.User> Users { get; set; }

    private void ValidateState()
    {
        if (string.IsNullOrEmpty(Name))
            throw new NullNameException();
    }

    public async Task Save(IRoleRepository repository)
    {
        ValidateState();

        if (Id == 0)
            await repository.CreateAsync(this);
        else
            await repository.UpdateAsync(this);
    }
}
