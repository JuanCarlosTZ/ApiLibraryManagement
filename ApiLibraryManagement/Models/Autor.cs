using System.ComponentModel.DataAnnotations;

public class Autor
{
    [Key]
    public int Id { get; set; }
    [Required]
    public string Nombre { get; set; } = null!;
    [Required]
    public string Nacionalidad { get; set; } = null!;
}