public interface ILibroRepository
{
  Task<IEnumerable<Libro>> GetAll();
  Task<Libro?> GetById(int libroId);
  Task<IEnumerable<Libro>> GetLibrosAntesDe2000();
  Task<Libro> Add(Libro libro);
  Task Update(Libro libro);
  Task Delete(int libroId);

  Task<bool> AutorExists(int autorId);
}