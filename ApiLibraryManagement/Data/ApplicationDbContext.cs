using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    public DbSet<Autor> Autores { get; set; }

    public DbSet<Libro> Libros { get; set; }

    public DbSet<Prestamo> Prestamos { get; set; }
    public DbSet<User> Usuarios { get; set; }
}