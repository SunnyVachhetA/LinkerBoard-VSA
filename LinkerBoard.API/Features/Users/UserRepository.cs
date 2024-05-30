using LinkerBoard.API.Data;

namespace LinkerBoard.API.Features.Users;

internal class UserRepository(LinkerBoardDbContext linkerBoardDbContext)
    : IUserRepository
{
    protected internal readonly LinkerBoardDbContext _linkerBoardDbContext = linkerBoardDbContext;
}