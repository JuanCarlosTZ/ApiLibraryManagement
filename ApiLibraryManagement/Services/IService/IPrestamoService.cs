public interface IPrestamoService
{
    Task<bool> AddPrestamo(AddPrestamoDto dto);
    Task<IEnumerable<PrestamoResponseDto>> GetPrestamosNoDevueltos();
    Task<bool> UpdatePrestamo(int prestamoId, UpdatePrestamoDto dto);
    Task<bool> DeletePrestamo(int prestamoId);
}