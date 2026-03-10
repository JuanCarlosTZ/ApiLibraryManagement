using Microsoft.EntityFrameworkCore;

public class LibroRepository : ILibroRepository
{
    private readonly ApplicationDbContext _db;

    public LibroRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Libro>> GetAll()
    {
        return await _db.Libros.Include(libro => libro.Autor).ToListAsync();
    }

    public async Task<Libro?> GetById(int libroId)
    {
        return await _db.Libros
            .Include(libro => libro.Autor)
            .FirstOrDefaultAsync(libro => libro.Id == libroId);
    }

    public async Task<IEnumerable<Libro>> GetLibrosAntesDe2000()
    {
        return await _db.Libros
            .Where(libro => libro.AnioPublicacion < 2000)
            .Select(libro => new Libro
            {
                Id = libro.Id,
                Titulo = libro.Titulo,
                AnioPublicacion = libro.AnioPublicacion
            })
            .ToListAsync();
    }


    public async Task<Libro> Add(Libro libro)
    {
        _db.Libros.Add(libro);
        await _db.SaveChangesAsync();
        return libro;
    }

    public async Task Update(Libro libro)
    {
        _db.Libros.Update(libro);
        await _db.SaveChangesAsync();
    }

    public async Task Delete(int libroId)
    {
        var libro = await _db.Libros.FindAsync(libroId);

        if (libro == null)
            throw new KeyNotFoundException("Libro no encontrado");

        _db.Libros.Remove(libro);
        await _db.SaveChangesAsync();
    }

    public async Task<bool> AutorExists(int autorId)
    {
        return await _db.Autores.AnyAsync(autor => autor.Id == autorId);
    }
}