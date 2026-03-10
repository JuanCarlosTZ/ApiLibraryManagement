using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class SeedService : ISeedService
{
    private readonly ApplicationDbContext _db;
    private readonly SeedMapper _mapper;

    public SeedService(ApplicationDbContext db, SeedMapper mapper)
    {
        _db = db;
        _mapper = mapper;
    }

    // ------------------ Seed Inicial ------------------
    /// Inicializa la base de datos de prueba con datos predeterminados
    public async Task Seed()
    {
        // Primero eliminamos todo
        await _DeletePrestamoAll();
        await _DeleteLibroAll();
        await _DeleteAutorAll();

        // --- Agregar Autores ---
        var autor1 = await _AddAutor(new AddAutorDto { Nombre = "Gabriel García Márquez", Nacionalidad = "Colombiana" });
        var autor2 = await _AddAutor(new AddAutorDto { Nombre = "Isabel Allende", Nacionalidad = "Chilena" });
        var autor3 = await _AddAutor(new AddAutorDto { Nombre = "J.K. Rowling", Nacionalidad = "Británica" });

        // --- Agregar Libros ---
        var libro1 = await _AddLibro(new AddLibroDto { Titulo = "Cien Años de Soledad", AutorId = autor1.Id, AnioPublicacion = 1967, Genero = "Novela" });
        var libro2 = await _AddLibro(new AddLibroDto { Titulo = "La Casa de los Espíritus", AutorId = autor2.Id, AnioPublicacion = 1982, Genero = "Novela" });
        var libro3 = await _AddLibro(new AddLibroDto { Titulo = "Harry Potter y la Piedra Filosofal", AutorId = autor3.Id, AnioPublicacion = 1997, Genero = "Fantasía" });
        var libro4 = await _AddLibro(new AddLibroDto { Titulo = "Harry Potter y la Cámara Secreta", AutorId = autor3.Id, AnioPublicacion = 1998, Genero = "Fantasía" });

        // --- Agregar Prestamos ---
        await _AddPrestamo(new AddPrestamoDto { LibroId = libro1.Id, FechaPrestamo = DateTime.Now.AddDays(-10) });
        await _AddPrestamo(new AddPrestamoDto { LibroId = libro2.Id, FechaPrestamo = DateTime.Now.AddDays(-5) });
        await _AddPrestamo(new AddPrestamoDto { LibroId = libro3.Id, FechaPrestamo = DateTime.Now.AddDays(-2) });
        // Este libro ya devuelto
        var prestamoDevuelto = await _AddPrestamo(new AddPrestamoDto { LibroId = libro4.Id, FechaPrestamo = DateTime.Now.AddDays(-20) });
        prestamoDevuelto.FechaDevolucion = DateTime.Now.AddDays(-10);
        await _db.SaveChangesAsync();

    }


    // ------------------ Get All ------------------

    public async Task<IEnumerable<SeedAutorResponseDto>> GetAllAutores()
    {
        return _db.Autores.Select(a => _mapper.ToSeedResponse(a));
    }

    public async Task<IEnumerable<SeedLibroResponseDto>> GetAllLibros()
    {
        return _db.Libros.Select(l => _mapper.ToSeedResponse(l));
    }

    public async Task<IEnumerable<SeedPrestamoResponseDto>> GetAllPrestamos()
    {
        return _db.Prestamos.Include(p => p.Libro).ThenInclude(l => l.Autor).Select(p => _mapper.ToSeedResponse(p));
    }


    // ------------------ Delete All ------------------
    public async Task _DeleteAutorAll()
    {
        _db.Autores.RemoveRange(_db.Autores);
        await _db.SaveChangesAsync();
    }

    public async Task _DeleteLibroAll()
    {
        _db.Libros.RemoveRange(_db.Libros);
        await _db.SaveChangesAsync();
    }

    public async Task _DeletePrestamoAll()
    {
        _db.Prestamos.RemoveRange(_db.Prestamos);
        await _db.SaveChangesAsync();
    }

    public async Task<Autor> _AddAutor(AddAutorDto dto)
    {
        var autor = new Autor
        {
            Nombre = dto.Nombre,
            Nacionalidad = dto.Nacionalidad
        };

        _db.Autores.Add(autor);
        await _db.SaveChangesAsync();
        return autor;
    }

    public async Task<Libro> _AddLibro(AddLibroDto dto)
    {
        var libro = new Libro
        {
            Titulo = dto.Titulo,
            AutorId = dto.AutorId,
            AnioPublicacion = dto.AnioPublicacion,
            Genero = dto.Genero
        };

        _db.Libros.Add(libro);
        await _db.SaveChangesAsync();
        return libro;
    }

    public async Task<Prestamo> _AddPrestamo(AddPrestamoDto dto)
    {
        // Prestamos iniciales siempre sin devolver
        var prestamo = new Prestamo
        {
            LibroId = dto.LibroId,
            FechaPrestamo = dto.FechaPrestamo,
            FechaDevolucion = null
        };

        _db.Prestamos.Add(prestamo);
        await _db.SaveChangesAsync();
        return prestamo;
    }



}