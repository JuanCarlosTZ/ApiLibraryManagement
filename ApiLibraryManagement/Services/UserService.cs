using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using ApiLibraryManagement;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepo;
    private readonly UserMapper _mapper;

    private readonly string? secretKey;


    public UserService(IUserRepository userRepo, UserMapper mapper)
    {
        _userRepo = userRepo;
        _mapper = mapper;
        secretKey = EnvConfig.JwtSecret;
    }


    public async Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto)
    {

        Console.WriteLine("Login test 2");

        var user = await _userRepo.GetByUsername(loginUserDto.Username);
        if (user == null)
        {
            throw new UnauthorizedAccessException("Usuario no encontrado");
            // return _mapper.ToLoginError(null, null, message: "Username no encontrado");
        }

        Console.WriteLine("Login test 3");

        if (!BCrypt.Net.BCrypt.Verify(loginUserDto.Password, user.Password))
        {
            throw new UnauthorizedAccessException("Credenciales incorrectas");
        }

        Console.WriteLine("Login test 4");
        Console.WriteLine(secretKey);
        Console.WriteLine("secretKey");



        // JWT Generador
        var handlerToken = new JwtSecurityTokenHandler();
        if (string.IsNullOrWhiteSpace(secretKey))
        {

            throw new InvalidOperationException("SecretKey no está configurada");
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
        var tokenString = handlerToken.WriteToken(token);

        return _mapper.ToLoginUserResponse(user, tokenString);

    }

    public async Task<User> Register(CreateUserDto createUserDto)
    {
        var encriptedPassword = BCrypt.Net.BCrypt.HashPassword(createUserDto.Password);
        createUserDto.Password = encriptedPassword;

        var user = _mapper.ToEntity(createUserDto);
        return await _userRepo.Add(user);
    }

    public async Task<User?> GetUserById(int id)
    {
        return await _userRepo.GetById(id);
    }



}