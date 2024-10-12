using System.ComponentModel.DataAnnotations;

namespace Shared.Models;

public class Sistemas
{
    [Key]
    public int SistemaId { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string? Sistema { get; set; }

    [Required(ErrorMessage = "Campo Obligatorio")]
    public string? Descripcion { get; set; }
}
