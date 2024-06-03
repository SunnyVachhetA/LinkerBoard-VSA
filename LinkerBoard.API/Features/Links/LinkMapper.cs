using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common;

namespace LinkerBoard.API.Features.Links;

internal static class LinkMapper {
    internal static Link ToEntity(this UpsertLinkRequestDto dto)
    {
        return new()
        {
            Title = dto.Title,
            Note = dto.Note,
            Url = dto.Url,
            LinkBoardId = dto.LinkBoardId,
            CreatedAt = DateHelper.TodayDate
        };
    }
    
    internal static Link ToEntity(this UpsertLinkRequestDto dto,
        Link entity)
    {
        entity.UpdatedAt = DateHelper.TodayDate;
        entity.LinkBoardId = dto.LinkBoardId == 0 ? entity.LinkBoardId : dto.LinkBoardId;
        entity.Title = string.IsNullOrWhiteSpace(dto.Title) ? entity.Title : dto.Title;
        entity.Note = string.IsNullOrWhiteSpace(dto.Note) ? entity.Note : dto.Note;
        entity.Url = string.IsNullOrWhiteSpace(dto.Url) ? entity.Url : dto.Url;
        return entity;
    }
    
    internal static LinkResponseDto ToDto(this Link entity)
    {
        return new LinkResponseDto(entity.Id,
            entity.Title,
            entity.Note,
            entity.Url,
            entity.CreatedAt,
            entity.UpdatedAt);
    }
}