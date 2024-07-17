using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos;

public class UpdateClienteDto
{
    [Required]
    public string Nome { get; set; }
}
