using Microsoft.AspNetCore.Mvc;

namespace ApiLibraryManagement.Controllers
{
    [ApiController]
    [Route("seed")]
    public class LibroController : ControllerBase
    {
        private readonly ISeedService _seedService;

        public LibroController(ISeedService seedService)
        {
            _seedService = seedService;
        }


        [HttpPost()]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> SeedData()
        {
            await _seedService.Seed();
            return Ok(new { message = "Data inicial cargada correctamente." });
        }


        [HttpGet("autores")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllAutores()
        {
            var response = await _seedService.GetAllAutores();
            return Ok(response);
        }


        [HttpGet("libros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllLibros()
        {
            var response = await _seedService.GetAllLibros();
            return Ok(response);
        }


        [HttpGet("prestamos")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status403Forbidden)]
        public async Task<IActionResult> GetAllPrestamos()
        {
            var response = await _seedService.GetAllPrestamos();
            return Ok(response);
        }
    }
}