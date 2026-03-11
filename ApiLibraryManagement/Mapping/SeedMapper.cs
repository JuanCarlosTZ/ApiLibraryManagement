using System.Collections.Generic;
using System.Linq;

public class SeedMapper
{

    public SeedAutorResponseDto ToSeedResponse(Autor autor)
    {
        return new SeedAutorResponseDto
        {
            AutorId = autor.Id,
            Nombre = autor.Nombre,
            Nacionalidad = autor.Nacionalidad,
        };
    }


    public SeedLibroResponseDto ToSeedResponse(Libro libro)
    {
        return new SeedLibroResponseDto
        {
            LibroId = libro.Id,
            Titulo = libro.Titulo,
            AnioPublicacion = libro.AnioPublicacion,
            Genero = libro.Genero,
            AutorId = libro.AutorId
        };
    }

    public SeedPrestamoResponseDto ToSeedResponse(Prestamo prestamo)
    {
        return new SeedPrestamoResponseDto
        {
            Id = prestamo.Id,
            FechaPrestamo = prestamo.FechaPrestamo,
            FechaDevolucion = prestamo.FechaDevolucion,
            LibroId = prestamo.LibroId,
            Titulo = prestamo.Libro.Titulo,
            AutorId = prestamo.Libro.AutorId,
            Nombre = prestamo.Libro.Autor.Nombre
        };
    }

    public SeedUsuarioResponseDto ToSeedResponse(User usuario)
    {
        return new SeedUsuarioResponseDto
        {
            Name = usuario.Name ?? "",
            Username = usuario.Username,
            Role = usuario.Role,
        };
    }

    public SeedUsuarioResponseDto ToSeedResponse(CreateUserDto usuario)
    {
        return new SeedUsuarioResponseDto
        {
            Name = usuario.Name ?? "",
            Username = usuario.Username,
            Role = usuario.Role,
        };
    }

}