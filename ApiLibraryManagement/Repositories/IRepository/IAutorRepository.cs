public interface IAutorRepository
{
    Task<IEnumerable<Autor>> GetAll();
    Task<Autor?> GetById(int autorId);
    Task<Autor> Add(Autor autor);
    Task Update(Autor autor);
    Task Delete(int autorId);
}