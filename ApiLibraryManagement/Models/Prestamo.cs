using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Prestamo
{
    [Key]
    public int Id { get; set; }

    [Required]
    public int LibroId { get; set; }

    [Required]
    public DateTime FechaPrestamo { get; set; }

    public DateTime? FechaDevolucion { get; set; }

    // Relación
    [ForeignKey("LibroId")]
    public Libro Libro { get; set; } = null!;

}