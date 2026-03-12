using System.Net;
using System.Net.Http.Json;
using FluentAssertions;
using Microsoft.AspNetCore.Http;

public class LibrosControllerIntegrationTests : IClassFixture<CustomWebApplicationFactory<Program>>
{
    private readonly HttpClient _client;

    public LibrosControllerIntegrationTests(CustomWebApplicationFactory<Program> factory)
    {
        _client = factory.CreateClient();
    }

    [Fact] // Se ejecuta antes de los tests de la clase
    public async Task InitializeAsync()
    {

        // Ejecutar
        var response = await _client.PostAsync("/seed", null);

        // Validar
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task GetLibrosAntesDe2000_ReturnsOk()
    {
        // Ejecutar
        var response = await _client.GetAsync("/libros/antes-de-2000");

        // Validar
        response.EnsureSuccessStatusCode();
        var libros = await response.Content.ReadFromJsonAsync<List<LibroResponseDto>>();
        libros.Should().NotBeNull();
    }

    [Fact]
    public async Task AddLibro_ReturnsCreated_WhenValid()
    {
        // Prepara
        var libro = new AddLibroDto
        {
            Titulo = "Libro Test",
            AnioPublicacion = 1999,
            AutorId = 1
        };

        // Ejecutar
        var response = await _client.PostAsJsonAsync("/libros", libro);

        // Validar
        response.StatusCode.Should().Be(HttpStatusCode.Created);
        var createdLibro = await response.Content.ReadFromJsonAsync<LibroResponseDto>();
        createdLibro.Should().NotBeNull();
        createdLibro.Titulo.Should().Be("Libro Test");
    }
}