

public class LibroMapper
{
    public LibroResponseDto ToResponse(Libro libro)
    {
        return new LibroResponseDto
        {
            Titulo = libro.Titulo,
            LibroId = libro.Id,
            AnioPublicacion = libro.AnioPublicacion
        };
    }

    public Libro ToEntity(AddLibroDto libroDto)
    {
        return new Libro()
        {
            Titulo = libroDto.Titulo,
            AutorId = libroDto.AutorId,
            AnioPublicacion = libroDto.AnioPublicacion,
            Genero = libroDto.Genero
        };
    }

}