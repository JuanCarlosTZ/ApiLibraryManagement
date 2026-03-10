using Microsoft.EntityFrameworkCore;

public class PrestamoRepository : IPrestamoRepository
{
    private readonly ApplicationDbContext _db;

    public PrestamoRepository(ApplicationDbContext db)
    {
        _db = db;
    }

    public async Task<IEnumerable<Prestamo>> GetAll()
    {
        return await _db.Prestamos
            .Include(p => p.Libro)
            .ThenInclude(l => l.Autor)
            .ToListAsync();
    }

    public async Task<Prestamo?> GetById(int prestamoId)
    {
        return await _db.Prestamos.FindAsync(prestamoId);
    }

    public async Task<List<Prestamo>> GetPrestamosNoDevueltos()
    {
        return await _db.Prestamos.Include(p => p.Libro).ThenInclude(l => l.Autor)
            .Where(p => p.FechaDevolucion == null)
            .Select(prestamo => prestamo)
            .ToListAsync();
    }
    public async Task<Prestamo> Add(Prestamo prestamo)
    {
        _db.Prestamos.Add(prestamo);
        await _db.SaveChangesAsync();
        return prestamo;
    }

    public async Task UpdateFechaDevolucion(int prestamoId, DateTime fechaDevolucion)
    {
        var prestamo = await _db.Prestamos.FindAsync(prestamoId);

        if (prestamo == null)
            throw new KeyNotFoundException("Prestamo no encontrado");

        prestamo.FechaDevolucion = fechaDevolucion;

        await _db.SaveChangesAsync();
    }

    public async Task Delete(int prestamoId)
    {
        var prestamo = await _db.Prestamos.FindAsync(prestamoId);

        if (prestamo == null)
            throw new KeyNotFoundException("Prestamo no encontrado");

        _db.Prestamos.Remove(prestamo);
        await _db.SaveChangesAsync();
    }
}