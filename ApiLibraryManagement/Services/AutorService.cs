public class AutorService : IAutorService
{
    private readonly AutorRepository _repo;
    private readonly AutorMapper _mapper;

    public AutorService(AutorRepository repo, AutorMapper mapper)
    {
        _repo = repo;
        _mapper = mapper;
    }

    public async Task<Autor> AddAutor(AddAutorDto dto)
    {
        var autor = _mapper.ToEntity(dto);
        await _repo.Add(autor);
        return autor;
    }

    public Task<Autor?> GetAutorById(int id)
    {
        return _repo.GetById(id)
            .ContinueWith(autor => autor.Result != null ? autor.Result : null);
    }

    public Task DeleteAutorAll()
    {
        return _repo.DeleteAll();
    }
}