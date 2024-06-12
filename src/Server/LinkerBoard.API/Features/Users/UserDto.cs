namespace LinkerBoard.API.Features.Users;

public record UserDto(Guid Id, string Username, string Email, DateOnly? CreatedAt, DateOnly? UpdateAt);