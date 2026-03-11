using System.Collections.Generic;
using System.Linq;

public class UserMapper
{

    public LoginUserResponseDto ToLoginUserResponse(User user, string token)
    {
        var userProfile = new UserDto
        {
            Name = user?.Name,
            Username = user?.Username,
            Role = user?.Role
        };

        return new LoginUserResponseDto
        {
            User = userProfile,
            Token = token,
        };
    }


    public LoginUserResponseDto ToLoginError(User? user, string? token, string? message)
    {
        var userProfile = (user == null) ? null
        : new UserDto
        {
            Name = user?.Name,
            Username = user?.Username,
            Role = user?.Role
        };

        return new LoginUserResponseDto
        {
            User = userProfile,
            Token = token,
            Message = message
        };
    }



    public User ToEntity(CreateUserDto dto)
    {
        return new User()
        {
            Name = dto.Name,
            Username = dto.Username,
            Password = dto.Password,
            Role = dto.Role
        };
    }

}