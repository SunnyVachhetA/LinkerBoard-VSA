using LinkerBoard.API.Data;
using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Features.LinkBoards;

internal sealed class LinkBoardService(LinkerBoardDbContext dbContext)
    : ILinkBoardService
{
    private readonly Guid _userId = Guid.Parse("114cc3cb-2420-4662-84c9-92e19af1227a");
    private readonly LinkerBoardDbContext _dbContext = dbContext;
    
    public async Task<UpsertLinkBoardResponseDto> CreateAsync(UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken)
    {
        LinkBoard linkBoardEntity = linkBoardDto.ToEntity();
        linkBoardEntity.UserId = _userId;
        
        await _dbContext.AddAsync(linkBoardEntity, cancellationToken);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return linkBoardEntity.ToDto();
    }

    public async Task<UpsertLinkBoardResponseDto> UpdateAsync(UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken)
    {
        LinkBoard? linkBoardEntity = await _dbContext.LinkBoards
            .FirstOrDefaultAsync(x => x.Id == linkBoardDto.Id && x.UserId == _userId, cancellationToken);
        
        if(linkBoardDto is null) throw new UnprocessableException("Can't process Link Board Request. Please try again.");
        
        linkBoardEntity.UpdatedAt = DateHelper.TodayDate;
        linkBoardEntity.Title = linkBoardDto.Title;
        
        _dbContext.Update(linkBoardEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return linkBoardEntity.ToDto();
    }
}