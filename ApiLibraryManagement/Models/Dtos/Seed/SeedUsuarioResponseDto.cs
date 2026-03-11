using System.Text.Json.Serialization;
using System.Collections.Generic;

// DTO base que se retornará al cliente
public class SeedUsuarioResponseDto
{
    [JsonPropertyName("name")]
    public string Name { get; set; } = null!;

    [JsonPropertyName("username")]
    public string Username { get; set; } = null!;

    [JsonPropertyName("role")]
    public string Role { get; set; } = null!;
}