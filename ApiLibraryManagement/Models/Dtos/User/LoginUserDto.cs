using System.ComponentModel.DataAnnotations;

public class LoginUserDto
{
  [Required(ErrorMessage = "El campo username es requerido")]
  public required string Username { get; set; }
  [Required(ErrorMessage = "El campo password es requerido")]
  public required string Password { get; set; }
}