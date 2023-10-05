using Application.User.Requests;
using Application.User.Responses;

namespace Application.User.Ports;
public interface IUserManager
{
    Task <UserResponse> CreateAsync(CreateUserRequest request);
    Task <UserResponse> UpdateAsync(UpdateUserRequest request);
    Task DeleteAsync(int id);
    Task<UserResponse> GetUserByIdAsync(int id);
    Task<UserResponse> GetUserAsync();
}
