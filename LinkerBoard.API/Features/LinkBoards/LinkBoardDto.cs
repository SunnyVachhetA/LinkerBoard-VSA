using System.ComponentModel.DataAnnotations;

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