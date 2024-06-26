using LinkerBoard.API.Domain;
using Microsoft.AspNetCore.Mvc;

namespace LinkerBoard.API.Features.Users;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController(IUserService userService)
    : ControllerBase
{
    private readonly IUserService _userService = userService;

    [HttpGet]
    public async Task<IActionResult> GetAll(CancellationToken cancellationToken)
    {
        IEnumerable<User> users = await _userService.GetAll(cancellationToken);

        return Ok(users);
    }

    [HttpPost]
    public async Task<IActionResult> Register([FromBody] UserDto userDto,
        CancellationToken cancellationToken)
    {
        userDto = await _userService.AddAsync(userDto, cancellationToken);

        return Ok(userDto);
    }
}