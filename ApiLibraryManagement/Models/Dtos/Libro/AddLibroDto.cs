using System.ComponentModel.DataAnnotations;

public class AddLibroDto
    {
    [Required(ErrorMessage = "El título del libro es obligatorio.")]
    [StringLength(200, MinimumLength = 1, ErrorMessage = "El título debe tener entre 1 y 200 caracteres.")]
    public string Titulo { get; set; } = null!;

    [Required(ErrorMessage = "El ID del autor es obligatorio.")]
    [Range(1, int.MaxValue, ErrorMessage = "El AutorId debe ser un número positivo.")]
    public int AutorId { get; set; }

    [Required(ErrorMessage = "El año de publicación es obligatorio.")]
    [Range(1450, 2100, ErrorMessage = "El año de publicación debe estar entre 1450 y 2100.")]
    public int AnioPublicacion { get; set; }

    [StringLength(50, ErrorMessage = "El género no puede superar los 50 caracteres.")]
    public string? Genero { get; set; }
    }