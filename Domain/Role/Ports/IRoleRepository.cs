namespace Domain.Role.Ports;

public interface IRoleRepository
{
    Task<int> CreateAsync(Entities.Role role);
    Task<Entities.Role> UpdateAsync(Entities.Role role);
    Task DeleteUserAsync(Entities.Role role);
    Task<Entities.Role> GetRoleByIdAsync(int id);
    Task<List<Entities.Role>> GetRolesAsync();
}
