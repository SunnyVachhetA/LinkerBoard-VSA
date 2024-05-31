using LinkerBoard.API.Features.Common;
using LinkerBoard.API.Domain;
namespace LinkerBoard.API.Features.Users;

public interface IUserService : IService
{
    internal Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default);
}