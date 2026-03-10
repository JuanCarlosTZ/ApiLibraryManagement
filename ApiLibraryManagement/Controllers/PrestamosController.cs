using Microsoft.AspNetCore.Mvc;

namespace ApiLibraryManagement.Controllers
{
    [ApiController]
    [Route("prestamos")]
    public class PrestamosController : ControllerBase
    {
        private readonly IPrestamoService _prestamoService;

        public PrestamosController(IPrestamoService prestamoService)
        {
            _prestamoService = prestamoService;
        }


        [HttpGet("no-devueltos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetPrestamosNoDevueltos()
        {
            try
            {
                var prestamos = await _prestamoService.GetPrestamosNoDevueltos();
                return Ok(prestamos);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }


        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateFechaDevolucion(int id, [FromBody] UpdatePrestamoDto dto)
        {
            var result  =await _prestamoService.UpdatePrestamo(id, dto);
            if (!result) return StatusCode(404, new { message = "El prestamo no existe" });

            return Ok();
        }



        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> RemovePrestamo(int id)
        {
            var result = await _prestamoService.DeletePrestamo(id);
            if (!result) return StatusCode(404, new { message = "El prestamo no existe" });

            return Ok(new { message = "Eliminado satisfactoriamente" });
        }
    }
}