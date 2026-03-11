using Microsoft.EntityFrameworkCore;

public class UserRepository : IUserRepository
{
    private readonly ApplicationDbContext _db;

    public UserRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<User> Add(User user)
    {
        _db.Usuarios.Add(user);
        await _db.SaveChangesAsync();
        return user;
    }

    public async Task<IEnumerable<User>> GetAll()
    {
        return await _db.Usuarios.ToListAsync();
    }

    public async Task<User?> GetById(int userId)
    {
        return await _db.Usuarios.FirstOrDefaultAsync(user => user.Id == userId);
    }

    public async Task<User?> GetByUsername(string username)
    {
        return await _db.Usuarios.FirstOrDefaultAsync(user => user.Username.ToLower().Trim() == username.ToLower().Trim());
    }


}