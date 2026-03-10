using Microsoft.AspNetCore.Http.HttpResults;

public class LibroService : ILibroService
{
    private readonly LibroRepository _libroRepo;
    private readonly AutorRepository _autorRepo;
    private readonly LibroMapper _mapper;

    public LibroService(LibroRepository libroRepo, AutorRepository autorRepo, LibroMapper mapper)
    {
        _libroRepo = libroRepo;
        _autorRepo = autorRepo;
        _mapper = mapper;
    }

    public async Task<LibroResponseDto> AddLibro(AddLibroDto dto)
    {
        var autor = await _autorRepo.GetById(dto.AutorId);
        if (autor == null)
            throw new BadHttpRequestException("El autor no existe");

        var libro = _mapper.ToEntity(dto);
        await _libroRepo.Add(libro);

        return _mapper.ToResponse(libro);
    }

    public async Task<IEnumerable<LibroResponseDto>> GetLibrosAntesDe2000()
    {
        var libros = await _libroRepo.GetLibrosAntesDe2000();
        return libros.Select(l => _mapper.ToResponse(l));
    }

}