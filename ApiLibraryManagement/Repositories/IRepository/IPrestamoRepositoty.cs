public interface IPrestamoRepository
{
    Task<IEnumerable<Prestamo>> GetAll();
    Task<Prestamo?> GetById(int prestamoId);

    Task<List<Prestamo>> GetPrestamosNoDevueltos();

    Task<Prestamo> Add(Prestamo prestamo);

    Task UpdateFechaDevolucion(int prestamoId, DateTime fechaDevolucion);

    Task Delete(int prestamoId);
}