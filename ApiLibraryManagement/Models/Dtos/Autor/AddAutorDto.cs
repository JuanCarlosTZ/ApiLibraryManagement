using System.ComponentModel.DataAnnotations;

public class AddAutorDto
    {
    [Required(ErrorMessage = "El nombre del autor es obligatorio.")]
    [StringLength(100, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 100 caracteres.")]
    public string Nombre { get; set; } = null!;

    [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
    [StringLength(50, MinimumLength = 2, ErrorMessage = "La nacionalidad debe tener entre 2 y 50 caracteres.")]
    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "La nacionalidad solo puede contener letras y espacios.")]
    public string Nacionalidad { get; set; } = null!;
    }