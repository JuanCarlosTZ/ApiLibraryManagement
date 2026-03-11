using Microsoft.AspNetCore.Http.HttpResults;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly UserMapper _mapper;

    public UserService(IUserRepository userRepo, UserMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
    }


    public async Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto)
    {
        if (string.IsNullOrEmpty(loginUserDto.Username))
        {
            return _mapper.ToLoginError(message: "El Username es requerido");
        }

        var user = await _userRepo.GetByUsername(loginUserDto.Username);
        if (user == null)
        {
            return _mapper.ToLoginError(message: "Username no encontrado");
        }

        if (!BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password))
        {
            return _mapper.ToLoginError(message: "Credenciales son incorrectas");
        }


        // JWT
        var handlerToken = new JwtSecurityTokenHandler();
        if (string.IsNullOrWhiteSpace(secretKey))
        {
            throw new InvalidOperationException("SecretKey no esta configurada");
        }



        var key = Encoding.UTF8.GetBytes(secretKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[]
          {
        new Claim("id",user.Id.ToString()),
        new Claim("username",user.Username),
        new Claim(ClaimTypes.Role,user.Role ?? string.Empty),
      }
          ),
            Expires = DateTime.UtcNow.AddHours(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = handlerToken.CreateToken(tokenDescriptor);
        return new UserLoginResponseDto()
        {
            Token = handlerToken.WriteToken(token),
            User = new UserRegisterDto()
            {
                Username = user.Username,
                Name = user.Name,
                Role = user.Role,
                Password = user.Password ?? ""
            },
            Message = "Usuario logueado correctamente"
        };

    }

    public async Task<User> Register(CreateUserDto createUserDto)
    {
        var encriptedPassword = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
        createUserDto.Password = encriptedPassword;

        var user = _mapper.ToEntity(createUserDto);
        return await _userRepo.Add(user);
    }


}