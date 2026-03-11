public interface IUserService
{
  Task<ICollection<User>> GetUsers();
  Task<User?> GetUser(int id);
  Task<UserLoginResponseDto> Login(UserLoginDto userLoginDto);
  Task<User> Register(CreateUserDto createUserDto);
}