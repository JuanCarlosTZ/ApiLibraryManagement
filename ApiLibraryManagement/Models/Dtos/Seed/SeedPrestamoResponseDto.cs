using System.Text.Json.Serialization;

public class SeedPrestamoResponseDto : PrestamoResponseDto

{
    [JsonPropertyName("prestamo_id")]
    public int Id { get; set; }

    [JsonPropertyName("fecha_prestamo")]
    public DateTime FechaPrestamo { get; set; }

    [JsonPropertyName("fecha_devolucion")]
    public DateTime? FechaDevolucion { get; set; }
}