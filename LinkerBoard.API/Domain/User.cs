namespace LinkerBoard.API.Domain;

internal sealed class User
    : BaseEntity<Guid>
{
    internal string Username { get; set;}
    
    internal string Email { get; set; }
    
    internal DateOnly CreatedAt { get; set; }
    
    internal DateOnly UpdatedAt { get;set;}
    
    internal User() {}
    
    internal User(string username,
        string email,
        DateOnly createdAt)
    {
        Username = username;
        Email = email;
        CreatedAt = createdAt;
    }
}