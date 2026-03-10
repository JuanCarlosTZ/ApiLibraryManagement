public interface ISeedService
{
    Task<Libro> _AddLibro(AddLibroDto dto);
    Task<Autor> _AddAutor(AddAutorDto dto);
    Task<Prestamo> _AddPrestamo(AddPrestamoDto dto);

    Task<IEnumerable<SeedAutorResponseDto>> GetAllAutores();
    Task<IEnumerable<SeedLibroResponseDto>> GetAllLibros();
    Task<IEnumerable<SeedPrestamoResponseDto>> GetAllPrestamos();

    Task _DeleteAutorAll() ;
    Task _DeleteLibroAll();
    Task _DeletePrestamoAll();

    Task Seed();
}