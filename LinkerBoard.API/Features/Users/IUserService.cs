using LinkerBoard.API.Features.Common;
using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common.Markers;

namespace LinkerBoard.API.Features.Users;

public interface IUserService : IService
{
    internal Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default);

    internal Task<UserDto> AddAsync(UserDto userDto, CancellationToken cancellationToken = default);
}