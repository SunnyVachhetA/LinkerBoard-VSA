using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common;

namespace LinkerBoard.API.Features.LinkBoards;

internal static class LinkBoardMapper
{
    public static LinkBoard ToEntity(this UpsertLinkBoardRequestDto dto) =>
        new()
        {
            Title = dto.Title,
            CreatedAt = DateHelper.TodayDate
        };

    public static UpsertLinkBoardResponseDto ToDto(this LinkBoard entity)
        => new(entity.Id, entity.Title, entity.CreatedAt, entity.UpdatedAt);
}