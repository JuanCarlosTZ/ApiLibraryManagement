using System.ComponentModel.DataAnnotations;

public class AddPrestamoDto
    {
    [Required(ErrorMessage = "El ID del libro es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El LibroId debe ser un número positivo.")]
    public int LibroId { get; set; }

    [Required(ErrorMessage = "La fecha del préstamo es obligatoria.")]
    [DataType(DataType.Date, ErrorMessage = "La fecha del préstamo debe ser una fecha válida.")]
    public DateTime FechaPrestamo { get; set; }

    [DataType(DataType.Date, ErrorMessage = "La fecha de devolución debe ser una fecha válida.")]
    public DateTime? FechaDevolucion { get; set; }
    }