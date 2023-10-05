using Application;
using Application.User.Dto;
using Application.User.Ports;
using Application.User.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IUserManager _userManager;

        public AccountController(IUserManager userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Post(
            [FromBody] UserDto dto
            )
        {
            var request = new CreateUserRequest
            {
                Data = dto
            };

            var res = await _userManager.CreateAsync(request);

            if (res.Success) return Created("", res);

            return res.ErrorCode switch
            {
                ErrorCode.USER_INVALID_EMAIL => BadRequest(res),
                ErrorCode.USER_INVALID_NAME => BadRequest(res),
                ErrorCode.USER_INVALID_LASTNAME => BadRequest(res),
                ErrorCode.USER_INVALID_PASSWORDHASH => BadRequest(res),
                _ => BadRequest(500)
            };
        }
    }
}
