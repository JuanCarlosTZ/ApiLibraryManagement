using System.ComponentModel.DataAnnotations;

public class CreateUserDto
{

    [Requiered(ErrorMessage = "El campo username es requerido")]
    public string Username { get; set; }
    [Required(ErrorMessage = "El campo name es requerido")]
    public string Name { get; set; }
    [Required(ErrorMessage = "El campo password es requerido")]
    public string Password { get; set; }
    [MinLength(6, ErrorMessage = "Password debe tener al menos 6 caracteres")]
    [Required(ErrorMessage = "El campo role es requerido")]
    public string Role { get; set; }
}