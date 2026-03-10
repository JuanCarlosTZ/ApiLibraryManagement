using System.Collections.Generic;
using System.Linq;

public class PrestamoMapper
{
    public PrestamoResponseDto ToResponse(Prestamo prestamo)
    {
        var libro = prestamo.Libro;
        return new PrestamoResponseDto
        {
            Titulo = libro.Titulo ?? "",
            LibroId = libro.Id,
            AutorId = libro.AutorId,
            Nombre = libro.Autor?.Nombre ?? "",

        };
    }

    public IEnumerable<PrestamoResponseDto> ToResponseList(IEnumerable<Prestamo> prestamos)
    {
        return prestamos.Select(ToResponse);
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