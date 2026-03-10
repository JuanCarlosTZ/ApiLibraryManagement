using System.Collections.Generic;
using System.Text.Json.Serialization;

public class SeedLibroResponseDto : LibroResponseDto
{
    // Información adicional del autor
    [JsonPropertyName("autor_id")]
    public int AutorId { get; set; }

    [JsonPropertyName("genero")]
    public string? Genero { get; set; } = null!;

    [JsonPropertyName("nacionalidad_autor")]
    public string NacionalidadAutor { get; set; } = null!;


}