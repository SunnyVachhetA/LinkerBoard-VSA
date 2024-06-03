namespace LinkerBoard.API.Features.Links;

public record LinkResponseDto(long Id,
    string Title,
    string? Note,
    string Url,
    DateOnly CreatedAt,
    DateOnly? UpdatedAt);

public record UpsertLinkRequestDto(long Id,
    string Title,
    string? Note,
    string Url,
    int LinkBoardId);