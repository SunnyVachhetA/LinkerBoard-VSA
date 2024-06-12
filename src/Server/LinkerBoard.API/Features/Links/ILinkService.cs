using LinkerBoard.API.Features.Common.Markers;

namespace LinkerBoard.API.Features.Links;

public interface ILinkService
    : IService
{
    Task<LinkResponseDto> UpsertAsync(UpsertLinkRequestDto linkRequestDto, CancellationToken cancellationToken);
    
    Task MoveLinkBoardAsync(long linkId, int boardId, CancellationToken cancellationToken);
    
    Task DeleteAsync(long linkId, CancellationToken cancellationToken);
}