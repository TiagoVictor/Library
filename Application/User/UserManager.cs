using Application.User.Dto;
using Application.User.Ports;
using Application.User.Requests;
using Application.User.Responses;
using Domain.User.Exceptions;
using Domain.User.Ports;
using SecureIdentity.Password;

namespace Application.User;
public class UserManager : IUserManager
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<UserResponse> CreateAsync(CreateUserRequest request)
    {
        try
        {
            var password = PasswordGenerator.Generate(length: 25, includeSpecialChars: true, upperCase: true);
            request.Data.PasswordHash = PasswordHasher.Hash(password);
            request.Data.Password = password;

            var user = UserDto.MapToEntity(request.Data);
            await user.Save(_userRepository);

            request.Data.Id = user.Id;

            return new UserResponse
            {
                Success = true,
                Data = request.Data
            };
        }
        catch (NullNameException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_NAME
            };
        }
        catch (NullLastNameException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_LASTNAME
            };
        }
        catch (NullEmailException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_EMAIL
            };
        }
        catch (NullPasswordHashException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_PASSWORDHASH
            };
        }
        catch (Exception)
        {
            return new UserResponse
            {
                Success = false,
                Message = "There was an error using DB.",
                ErrorCode = ErrorCode.USER_COLD_NOT_SAVE
            };
        }
    }

    public async Task DeleteAsync(int id)
    {
        var user = await _userRepository.GetUserByIdAsync(id);
        await _userRepository.DeleteUserAsync(user);
    }

    public async Task<UserResponse> GetUserAsync()
    {
        var users = await _userRepository.GetUsers();
        var userDto = new UserResponse();

        users.ForEach(x => userDto.Users.Add(UserDto.MapToDto(x)));

        return new UserResponse
        {
            Users = userDto.Users
        };
    }

    public async Task<UserResponse> GetUserByIdAsync(int id)
    {
        var user = UserDto.MapToDto(await _userRepository.GetUserByIdAsync(id));

        return new UserResponse
        {
            Data = user
        };
    }

    public async Task<UserResponse> UpdateAsync(UpdateUserRequest request)
    {
        try
        {
            var user = await _userRepository.GetUserByIdAsync(request.Data.Id);

            if (user == null)
            {
                return new UserResponse
                {
                    Success = false,
                    ErrorCode = ErrorCode.USER_NOT_FOUND,
                    Message = "User not found"
                };
            }

            user.Name = request.Data.Name;
            user.LastName = request.Data.LastName;
            user.Email = request.Data.Email;

            await user.Save(_userRepository);

            request.Data.Id = user.Id;

            return new UserResponse
            {
                Success = true,
                Data = request.Data
            };
        }
        catch (NullNameException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_NAME
            };
        }
        catch (NullLastNameException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_LASTNAME
            };
        }
        catch (NullEmailException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_EMAIL
            };
        }
        catch (NullPasswordHashException ex)
        {
            return new UserResponse
            {
                Success = false,
                Message = ex.Message,
                ErrorCode = ErrorCode.USER_INVALID_PASSWORDHASH
            };
        }
        catch (Exception)
        {
            return new UserResponse
            {
                Success = false,
                Message = "There was an error using DB.",
                ErrorCode = ErrorCode.USER_COLD_NOT_UPDATE
            };
        }
    }
}
