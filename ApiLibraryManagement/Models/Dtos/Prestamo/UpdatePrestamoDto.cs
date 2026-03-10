using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

public class UpdatePrestamoDto
{
    [Required(ErrorMessage = "La fecha de devolución es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha de devolución debe ser una fecha válida.")]
    [JsonPropertyName("fecha_devolucion")]
    public DateTime FechaDevolucion { get; set; }
}