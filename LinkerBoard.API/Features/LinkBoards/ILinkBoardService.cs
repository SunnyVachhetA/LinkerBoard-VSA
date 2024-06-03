using LinkerBoard.API.Features.Common;

namespace LinkerBoard.API.Features.LinkBoards;

public interface ILinkBoardService
    : IService
{
    Task<UpsertLinkBoardResponseDto> CreateAsync(UpsertLinkBoardRequestDto linkBoardDto,
        CancellationToken cancellationToken);

    Task<UpsertLinkBoardResponseDto> UpdateAsync(UpsertLinkBoardRequestDto linkBoardDto, CancellationToken cancellationToken);
}