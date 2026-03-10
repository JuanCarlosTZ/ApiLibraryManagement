

public class PrestamoMapper
{
    public PrestamoResponseDto ToResponse(Prestamo prestamo)
    {
        return new PrestamoResponseDto
        {
            Titulo = prestamo.Libro.Titulo,
            LibroId = prestamo.LibroId,
            AutorId = prestamo.Libro.AutorId,
            Nombre = prestamo.Libro.Autor.Nombre,

        };
    }

    public Prestamo ToEntity(AddPrestamoDto prestamoDto)
    {
        return new Prestamo()
        {
            LibroId = prestamoDto.LibroId,
            FechaDevolucion = prestamoDto.FechaDevolucion,
            FechaPrestamo = prestamoDto.FechaPrestamo,
        };
    }

}