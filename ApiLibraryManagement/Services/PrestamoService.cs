using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PrestamoService : IPrestamoService
{
    private readonly PrestamoRepository _prestamoRepo;
    private readonly LibroRepository _libroRepo;
    private readonly AutorRepository _autorRepo;

    private readonly PrestamoMapper _prestamoMapper;

    public PrestamoService(
        PrestamoRepository prestamoRepo,
        LibroRepository libroRepo,
        AutorRepository autorRepo,

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

        return prestamos.Select(p => new PrestamoResponseDto
        {

            LibroId = p.LibroId,
            Titulo = p.Libro.Titulo,
            AutorId = p.Libro.AutorId,
            Nombre = p.Libro.Autor.Nombre
        });
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
