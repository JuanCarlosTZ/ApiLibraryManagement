using System.Text.Json.Serialization;

public class LibroResponseDto
    {
    [JsonPropertyName("libro_id")]
    public int LibroId { get; set; }

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = null!;

    [JsonPropertyName("anio_publicacion")]
    public int AnioPublicacion { get; set; }
    }