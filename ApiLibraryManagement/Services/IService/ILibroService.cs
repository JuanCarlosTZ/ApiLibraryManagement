
public interface ILibroService
{
    Task<LibroResponseDto> AddLibro(AddLibroDto dto);
    Task<IEnumerable<LibroResponseDto>> GetLibrosAntesDe2000();

}