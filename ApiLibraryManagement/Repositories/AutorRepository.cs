using Microsoft.EntityFrameworkCore;

public class AutorRepository : IAutorRepository
{
    private readonly ApplicationDbContext _db;

    public AutorRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<Autor> Add(Autor autor)
    {
        _db.Autores.Add(autor);
        await _db.SaveChangesAsync();
        return autor;
    }

    public async Task Delete(int autorId)
    {
        var autor = await _db.Autores.FindAsync(autorId);

        if (autor == null)
            throw new KeyNotFoundException("Autor no encontrado");

        _db.Autores.Remove(autor);
        await _db.SaveChangesAsync();
    }

    public async Task<IEnumerable<Autor>> GetAll()
    {
        return await _db.Autores.ToListAsync();
    }

    public async Task<Autor?> GetById(int autorId)
    {
        return await _db.Autores.FirstOrDefaultAsync(autor => autor.Id == autorId);
    }

    public async Task Update(Autor autor)
    {
        _db.Autores.Update(autor);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAll()
    {
        _db.Autores.RemoveRange(_db.Autores);
        await _db.SaveChangesAsync();
    }
}