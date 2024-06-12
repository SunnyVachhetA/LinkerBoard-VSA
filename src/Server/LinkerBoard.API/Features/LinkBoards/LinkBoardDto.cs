using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using LinkerBoard.API.Features.Common;
using LinkerBoard.API.Features.Links;

namespace LinkerBoard.API.Features.LinkBoards;

public record UpsertLinkBoardResponseDto(
    int Id,
    string Title,
    DateOnly CreatedAt,
    DateOnly? UpdatedAt);

public record UpsertLinkBoardRequestDto
{
    public UpsertLinkBoardRequestDto()
    {
    }

    public int Id { get; set; }

    [Required]
    [StringLength(255, MinimumLength = 3)]
    public string Title { get; set; } = string.Empty;

    public UpsertLinkBoardRequestDto(string title)
    {
        Title = title;
    }
}

public record FilterLinkBoardRequestDto
{
    public FilterLinkBoardRequestDto()
    { }

    public string? Title { get; set; } = string.Empty;

    public int PageNumber { get; set; } = 1;

    public int PageSize { get; set; } = 20;

    [JsonConverter(typeof(JsonStringEnumConverter))]
    public OrderByType? OrderByType { get; set; }

    public FilterLinkBoardRequestDto(string? title,
        int pageNumber,
        int pageSize,
        OrderByType? orderByType)
    {
        Title = title;
        PageNumber = pageNumber;
        PageSize = pageSize;
        OrderByType = orderByType;
    }
}

public record LinkBoardResponseDto(int Id,
    string Title,
    DateOnly CreatedAt,
    DateOnly? UpdatedAt,
    IEnumerable<LinkResponseDto> Links);