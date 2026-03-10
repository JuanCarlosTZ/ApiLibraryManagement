using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PrestamoService : IPrestamoService
{
    private readonly IPrestamoRepository _prestamoRepo;
    private readonly ILibroRepository _libroRepo;
    private readonly IAutorRepository _autorRepo;

    private readonly PrestamoMapper _prestamoMapper;

    public PrestamoService(
        IPrestamoRepository prestamoRepo,
        ILibroRepository libroRepo,
        IAutorRepository autorRepo,

PrestamoMapper prestamoMapper
        )
    {
        _prestamoRepo = prestamoRepo;
        _libroRepo = libroRepo;
        _autorRepo = autorRepo;
        _prestamoMapper = prestamoMapper;
    }

    public async Task<bool> AddPrestamo(AddPrestamoDto dto)
    {
        var prestamo = _prestamoMapper.ToEntity(dto);
        var result = await _prestamoRepo.Add(prestamo);
        return result != null;
    }

    public async Task<IEnumerable<PrestamoResponseDto>> GetPrestamosNoDevueltos()
    {
        var prestamos = await _prestamoRepo.GetPrestamosNoDevueltos();
        var result = _prestamoMapper.ToResponseList(prestamos);
        return result;
    }


    public async Task<bool> UpdatePrestamo(int prestamoId, UpdatePrestamoDto dto)
    {
        var prestamo = await _prestamoRepo.GetById(prestamoId);
        if (prestamo == null)
            return false;

        await _prestamoRepo.UpdateFechaDevolucion(prestamoId, dto.FechaDevolucion);
        return true;
    }


    public async Task<bool> DeletePrestamo(int prestamoId)
    {
        var prestamo = await _prestamoRepo.GetById(prestamoId);
        if (prestamo == null)
            return false;

        await _prestamoRepo.Delete(prestamoId);
        return true;
    }
}
