namespace LinkerBoard.API.Domain;

internal sealed class Link
    : BaseEntity<long>
{
    public string Title { get; set; }

    public string Url { get; set; }

    public string? Note { get; set; }

    public DateOnly CreatedAt { get; set; }

    public DateOnly? UpdatedAt { get; set; }

    public int LinkBoardId { get; set; }

    public LinkBoard LinkBoard { get; set; } = null!;
}