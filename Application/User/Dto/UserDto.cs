using Entity = Domain.User.Entities;

namespace Application.User.Dto;
public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { private get; set; }
    public string Password { get; set; }

    public static Entity.User MapToEntity(UserDto dto)
    {
        return new Entity.User
        {
            Id = dto.Id,
            Name = dto.Name,
            LastName = dto.LastName,
            Email = dto.Email,
            PasswordHash = dto.PasswordHash,
        };
    }

    public static UserDto MapToDto(Entity.User user)
    {
        return new UserDto
        {
            Id = user.Id,
            Name = user.Name,
            LastName = user.LastName,
            Email = user.Email,
            PasswordHash = user.PasswordHash,
        };
    }
}
