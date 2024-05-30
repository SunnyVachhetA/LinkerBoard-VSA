namespace LinkerBoard.API.Features.Users;

internal class UserService(IUserRepository userRepository)
    : IUserService
{
    private readonly IUserRepository _userRepository = userRepository;
}