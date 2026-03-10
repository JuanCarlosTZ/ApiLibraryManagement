public interface IAutorService
{
    Task<Autor?> GetAutorById(int id);
}