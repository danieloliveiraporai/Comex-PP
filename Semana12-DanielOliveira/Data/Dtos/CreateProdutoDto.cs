using System.ComponentModel.DataAnnotations;

namespace ComexAPI.Data.Dtos;

public class CreateProdutoDto
{
    [Required(ErrorMessage = "O Nome do Produto é obrigatório")]
    [StringLength(100, ErrorMessage = "O limite de caracteres é de 100")]
    public string Nome { get; set; }

    [StringLength(500, ErrorMessage = "O limite de caracteres é de 500")]
    public string Descricao { get; set; }

    [Required(ErrorMessage = "O Preço Unitário do Produto é Obrigatório")]
    [Range(1, int.MaxValue, ErrorMessage = "O valor deve ser maior que 0.")]
    public float PrecoUnitario { get; set; }

    [Required(ErrorMessage = "A Quantidade do Produto é Obrigatória")]
    [Range(0, int.MaxValue, ErrorMessage = "O valor deve ser maior ou igual a 0.")]
    public int Quantidade { get; set; }
}
