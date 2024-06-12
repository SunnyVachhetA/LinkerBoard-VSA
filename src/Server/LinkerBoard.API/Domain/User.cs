namespace LinkerBoard.API.Domain;

internal sealed class User
    : BaseEntity<Guid>
{
    public string Username { get; set;}
    
    public string Email { get; set; }
    
    public DateOnly CreatedAt { get; set; }
    
    public DateOnly? UpdatedAt { get;set;}
}