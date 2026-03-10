using Microsoft.AspNetCore.Http.HttpResults;

public class LibroService : ILibroService
{
    private readonly ILibroRepository _libroRepo;
    private readonly IAutorRepository _autorRepo;
    private readonly LibroMapper _mapper;

    public LibroService(ILibroRepository libroRepo, IAutorRepository autorRepo, LibroMapper mapper)
    {
        _libroRepo = libroRepo;
        _autorRepo = autorRepo;
        _mapper = mapper;
    }

    public async Task<LibroResponseDto> AddLibro(AddLibroDto dto)
    {
        var autor = await _autorRepo.GetById(dto.AutorId);
        if (autor == null)
            throw new KeyNotFoundException($"El autor con Id {dto.AutorId} no existe");

        if (string.IsNullOrWhiteSpace(dto.Titulo) || dto.AnioPublicacion <= 0)
            throw new ArgumentException("Datos del libro inválidos");

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