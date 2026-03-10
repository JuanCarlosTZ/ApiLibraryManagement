using System.Text.Json.Serialization;
using System.Collections.Generic;

// DTO base que se retornará al cliente
public class SeedAutorResponseDto
{
    [JsonPropertyName("autor_id")]
    public int AutorId { get; set; }

    [JsonPropertyName("nombre")]
    public string Nombre { get; set; } = null!;

    [JsonPropertyName("nacionalidad")]
    public string Nacionalidad { get; set; } = null!;
}