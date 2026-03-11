public interface IUserRepository
{
    Task<IEnumerable<User>> GetAll();
    Task<User?> GetById(int userId);
    Task<User?> GetByUsername(string username);
    Task<User> Add(User user);
}