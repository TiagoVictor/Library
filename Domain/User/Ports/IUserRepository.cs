namespace Domain.User.Ports;
public interface IUserRepository
{
    Task<int> CreateAsync(Entities.User user);
    Task<Entities.User> UpdateUser(Entities.User user);
    Task DeleteUserAsync(Entities.User user);
    Task<Entities.User> GetUserByIdAsync(int id);
    Task<List<Entities.User>> GetUsers();
}

