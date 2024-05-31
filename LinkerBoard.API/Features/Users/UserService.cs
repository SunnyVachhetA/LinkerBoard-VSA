using LinkerBoard.API.Data;
using LinkerBoard.API.Domain;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Features.Users;

internal class UserService(LinkerBoardDbContext linkerBoardDbContext)
    : IUserService
{
    private readonly LinkerBoardDbContext _dbContext = linkerBoardDbContext;

    public async Task<IEnumerable<User>> GetAll(CancellationToken cancellationToken = default)
    {
        List<User> result = await _dbContext.Users.ToListAsync(cancellationToken);

        return result;
    }
}