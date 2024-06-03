using LinkerBoard.API.Domain;
using LinkerBoard.API.Features.Common;

namespace LinkerBoard.API.Features.Users;

internal static class UserMapper
{
    internal static User ToEntity(this UserDto userDto)
    {
        return new User()
        {
            Username = userDto.Username,
            Email = userDto.Email,
            CreatedAt = DateHelper.TodayDate
        };
    }
}