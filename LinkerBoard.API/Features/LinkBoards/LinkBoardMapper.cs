using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common;
using LinkerBoard.API.Features.Links;

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

    public static IEnumerable<LinkBoardResponseDto> ToDto(this IEnumerable<LinkBoard> entities) =>
        entities
            .Select(x => new LinkBoardResponseDto(x.Id, x.Title, x.CreatedAt, x.UpdatedAt,
                x.Links.Select(d => new LinkResponseDto(d.Id, d.Title, d.Note, d.Url, d.CreatedAt, d.UpdatedAt))
                    .ToList()))
            .ToList();
}