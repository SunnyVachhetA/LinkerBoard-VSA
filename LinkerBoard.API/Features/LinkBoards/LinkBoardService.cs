using LinkerBoard.API.Data;
using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common;
using LinkerBoard.API.Features.Common.CriteriaHelper;
using LinkerBoard.API.Features.Common.Dto;
using Microsoft.EntityFrameworkCore;

namespace LinkerBoard.API.Features.LinkBoards;

internal sealed class LinkBoardService(LinkerBoardDbContext dbContext)
    : ILinkBoardService
{
//    private readonly Guid _userId = Guid.Parse("114cc3cb-2420-4662-84c9-92e19af1227a");
    private readonly Guid _userId = Guid.Parse("2c0352c9-70a2-43dc-86f2-010b6db22cb7");
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

        if (linkBoardDto is null) throw new UnprocessableException("Can't process Link Board Request. Please try again.");

        linkBoardEntity.UpdatedAt = DateHelper.TodayDate;
        linkBoardEntity.Title = linkBoardDto.Title;

        _dbContext.Update(linkBoardEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);

        return linkBoardEntity.ToDto();
    }

    public async Task<PageResponseDto<LinkBoardResponseDto>> FilterAsync(FilterLinkBoardRequestDto filterDto,
        CancellationToken cancellationToken)
    {
        FilterCriteria<LinkBoard> filterCriteria = PrepareFilterCriteriaForLinkBoard(filterDto);

        (long count, IEnumerable<LinkBoard> data) result =
            await _dbContext.LinkBoards.EvaluatePageQuery(filterCriteria, cancellationToken: cancellationToken);

        return new PageResponseDto<LinkBoardResponseDto>(filterDto.PageNumber,
            filterDto.PageSize,
            result.data.ToDto(),
            result.count);
    }

    public async Task DeleteAsync(int boardId,
        CancellationToken cancellationToken)
    {
        LinkBoard? linkBoardEntity = await _dbContext.LinkBoards
            .FirstOrDefaultAsync(x => x.Id == boardId && x.UserId == _userId, cancellationToken);

        if(linkBoardEntity is null) throw new ResourceNotFoundException($"Board not found for Id: {boardId}.");

        _dbContext.LinkBoards.Remove(linkBoardEntity);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    private FilterCriteria<LinkBoard> PrepareFilterCriteriaForLinkBoard(FilterLinkBoardRequestDto filterDto)
    {
        FilterCriteria<LinkBoard> filterCriteria = new()
        {
            PageNumber = filterDto.PageNumber < 0 ? 1 : filterDto.PageNumber,
            PageSize = filterDto.PageSize > AppConstant.MaxPageSize ? AppConstant.MaxPageSize : filterDto.PageSize,
            IncludeExpressions = [x => x.Links],
            FiltersExpressions = []
        };

        if (!string.IsNullOrWhiteSpace(filterDto.Title))
        {
            //TODO Need to change this because full text search is not working
            filterCriteria.FiltersExpressions.Add(x =>
                EF.Functions.ToTsVector("english", x.Title).Matches(filterDto.Title));
        }
        return filterCriteria;
    }
}