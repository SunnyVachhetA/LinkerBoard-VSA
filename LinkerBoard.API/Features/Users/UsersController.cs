using Microsoft.AspNetCore.Mvc;

namespace LinkerBoard.API.Features.Users;

[ApiController]
[Route("api/[controller]")]
public sealed class UsersController(IUserService userService) : ControllerBase
{
}