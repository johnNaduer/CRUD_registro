using System.ComponentModel.DataAnnotations;

public class Usuarios
{
    [Key]
    public int Id { get; set; }

    [MaxLength(20)]
    public string Nombre { get; set; }

    [MaxLength(10)]
    public string Clave { get; set; }
}

