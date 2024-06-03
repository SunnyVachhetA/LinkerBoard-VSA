using LinkerBoard.API.Features.Common.Dto;
using LinkerBoard.API.Features.Common.Markers;

namespace LinkerBoard.API.Features.LinkBoards;

public interface ILinkBoardService
    : IService
{
    Task<UpsertLinkBoardResponseDto> CreateAsync(UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken);

    Task<UpsertLinkBoardResponseDto> UpdateAsync(UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken);

    Task<PageResponseDto<LinkBoardResponseDto>> FilterAsync(FilterLinkBoardRequestDto filterDto,
        CancellationToken cancellationToken);

    Task DeleteAsync(int boardId,
        CancellationToken cancellationToken);
}