using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

public class Libro
{
    [Key]
    public int Id { get; set; }

    [Required]
    public string Titulo { get; set; } = null!;

    [Required]
    public int AutorId { get; set; }

    [Required]
    public int AnioPublicacion { get; set; }

    public string? Genero { get; set; }

    // Relaciones
    [ForeignKey("AutorId")]
    public Autor Autor { get; set; } = null!;

}