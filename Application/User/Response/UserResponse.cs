using Application.User.Dto;

namespace Application.User.Responses;
public class UserResponse : Response
{
    public UserDto? Data;
    public List<UserDto> Users = new();
}
