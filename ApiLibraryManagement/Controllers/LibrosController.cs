using Microsoft.AspNetCore.Mvc;

namespace ApiLibraryManagement.Controllers
{
    [ApiController]
    [Route("libros")]
    public class LibrosController : ControllerBase
    {
        private readonly ILibroService _libroService;

        public LibrosController(ILibroService libroService)
        {
            _libroService = libroService;
        }

        // GET /libros/antes-de-2000
        [HttpGet("antes-de-2000")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> GetLibrosAntesDel2000()
        {
            try
            {
                var libros = await _libroService.GetLibrosAntesDe2000();
                return Ok(libros);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        // POST /libros
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> AddLibro([FromBody] AddLibroDto libroDto)
        {
            try
            {
                var result = await _libroService.AddLibro(libroDto);
                return CreatedAtAction(nameof(GetLibrosAntesDel2000), new { id = result.LibroId }, result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }
    }
}