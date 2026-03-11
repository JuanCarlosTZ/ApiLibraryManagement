public interface IUserService
{
  Task<User?> GetUserById(int id);
  Task<LoginUserResponseDto> Login(LoginUserDto loginUserDto);
  Task<User> Register(CreateUserDto createUserDto);
}