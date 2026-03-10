using System.Text.Json.Serialization;

public class PrestamoResponseDto
    {
    [JsonPropertyName("autor_id")]
    public int AutorId { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = null!;

    [JsonPropertyName("libro_id")]
    public int LibroId { get; set; }

    [JsonPropertyName("titulo")]
    public string Titulo { get; set; } = null!;
    }