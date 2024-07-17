using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos;

public class UpdateEnderecoDto
{
    [Required]
    public string Nome { get; set; }
}
