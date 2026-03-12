using Moq;
using Microsoft.AspNetCore.Mvc;
using ApiLibraryManagement.Controllers;
using FluentAssertions;

public class LibrosControllerTests
{
    private readonly Mock<ILibroService> _mockService;
    private readonly LibrosController _controller;

    public LibrosControllerTests()
    {
        _mockService = new Mock<ILibroService>();
        _controller = new LibrosController(_mockService.Object);
    }



    [Fact] // LibrosAntesDe2000 con libros resultado exitoso
    public async Task GetLibrosAntesDe2000_ReturnsOk_WithBooks()
    {
        // Preparar
        var libros = new List<LibroResponseDto>
        {
            new LibroResponseDto { LibroId = 1, Titulo = "Libro Antiguo", AnioPublicacion = 1995 }
        };

        _mockService.Setup(s => s.GetLibrosAntesDe2000())
                    .ReturnsAsync(libros);

        // Ejecutar
        var result = await _controller.GetLibrosAntesDel2000();

        // Validar
        result.Should().NotBeNull();
        var okResult = Assert.IsType<OkObjectResult>(result);
        var returnedBooks = Assert.IsAssignableFrom<IEnumerable<LibroResponseDto>>(okResult.Value);

        Assert.Single(returnedBooks);
    }




    [Fact] // LibrosAntesDe2000 sin libros resultado exitoso
    public async Task GetLibrosAntesDe2000_ReturnsEmptyList()
    {
        // Preparar
        _mockService.Setup(s => s.GetLibrosAntesDe2000())
                    .ReturnsAsync(new List<LibroResponseDto>());

        // Ejecutar
        var result = await _controller.GetLibrosAntesDel2000();

        // Validar
        var okResult = Assert.IsType<OkObjectResult>(result);
        var books = Assert.IsAssignableFrom<IEnumerable<LibroResponseDto>>(okResult.Value);

        Assert.Empty(books);
    }


    [Fact] // Agregar Libro resultado exitoso
    public async Task CreateLibro_ReturnsCreated_WhenValid()
    {
        // Preparar
        var libro = new AddLibroDto
        {
            Titulo = "Nuevo Libro",
            AutorId = 1,
            AnioPublicacion = 1995
        };

        var libroCreado = new LibroResponseDto
        {
            LibroId = 1,
            Titulo = "Nuevo Libro",
            AnioPublicacion = 1995
        };

        _mockService.Setup(s => s.AddLibro(libro))
                    .ReturnsAsync(libroCreado);

        // Ejecutar
        var result = await _controller.AddLibro(libro);

        // Validar
        Assert.NotNull(result);
        var createdResult = Assert.IsType<ObjectResult>(result);
        Assert.Equal(libroCreado, createdResult.Value);
    }


    [Fact] // Agregar Libro con datos invalidos
    public async Task CreateLibro_ReturnsBadRequest_WhenModelInvalid()
    {
        // Preparar
        _controller.ModelState.AddModelError("Titulo", "Required");

        var libro = new AddLibroDto();

        // Ejecutar
        var result = await _controller.AddLibro(libro);

        // Validar
        Assert.IsType<BadRequestObjectResult>(result);
    }



    [Fact]  // Agregar Libro con datos invalidos - Autor no encontrado
    public async Task CreateLibro_ReturnsNotFound_WhenAutorDoesNotExist()
    {
        // Preparar
        var libro = new AddLibroDto
        {
            Titulo = "Libro",
            AutorId = 999
        };

        _mockService.Setup(s => s.AddLibro(libro))
                    .ThrowsAsync(new KeyNotFoundException());

        // Ejecutar
        var result = await _controller.AddLibro(libro);

        // Validar
        Assert.IsType<NotFoundObjectResult>(result);
    }
}
