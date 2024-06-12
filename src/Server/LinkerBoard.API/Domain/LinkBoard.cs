namespace LinkerBoard.API.Domain;

internal sealed class LinkBoard
    : BaseEntity<int>
{
    internal string Title { get; set; }
    
    internal Guid UserId { get; set; }

    internal DateOnly CreatedAt { get; set; }
    
    internal DateOnly? UpdatedAt { get;set; }

    internal User User { get; set; } = null!;
    
    internal ICollection<Link> Links { get; set; } = [];
}