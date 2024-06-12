using LinkerBoard.API.Data;
using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common;
using Microsoft.EntityFrameworkCore;
namespace LinkerBoard.API.Features.Links;

internal sealed class LinkService(LinkerBoardDbContext dbContext)
    : ILinkService
{
    private readonly LinkerBoardDbContext _dbContext = dbContext;
    
    public async Task<LinkResponseDto> UpsertAsync(UpsertLinkRequestDto linkRequestDto,
        CancellationToken cancellationToken)
    {
        Link? linkEntity = await _dbContext.Links
            .FirstOrDefaultAsync(x => x.Id == linkRequestDto.Id && x.LinkBoardId == linkRequestDto.LinkBoardId, cancellationToken);

        linkEntity = linkEntity is null
            ? linkRequestDto.ToEntity()
            : linkRequestDto.ToEntity(linkEntity);
        
        _dbContext.Links.Update(linkEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
        
        return linkEntity.ToDto();
    }

    public async Task MoveLinkBoardAsync(long linkId, int boardId, CancellationToken cancellationToken)
    {
        Link? linkEntity = await _dbContext.Links
            .FirstOrDefaultAsync(x => x.Id == linkId, cancellationToken);
        
        if(linkEntity is null) throw new UnprocessableException($"Unable to move Link: {linkId} to Board: {boardId}.");
        
        linkEntity.LinkBoardId = boardId;
        linkEntity.UpdatedAt = DateHelper.TodayDate;
        _dbContext.Links.Update(linkEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task DeleteAsync(long linkId, CancellationToken cancellationToken)
    {
        Link? linkEntity = await _dbContext.Links
            .FirstOrDefaultAsync(x => x.Id == linkId, cancellationToken);
        
        if(linkEntity is null) throw new UnprocessableException($"Unable to link Link: {linkId}");
        
        _dbContext.Links.Remove(linkEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }
}