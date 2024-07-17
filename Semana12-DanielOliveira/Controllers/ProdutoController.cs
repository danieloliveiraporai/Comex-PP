using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ProdutoController : ControllerBase
{
    private ProdutoContext Context;
    private IMapper Mapper;

    public ProdutoController(ProdutoContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    /// <summary>
    /// Adiciona um produto ao banco de dados
    /// </summary>
    /// <param name="produtoDto">Objeto com os campos necessários para criação de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost]
    public IActionResult AdicionarProduto([FromBody] CreateProdutoDto produtoDto)
    {
        Produto produto = Mapper.Map<Produto>(produtoDto);
        Context.Produtos.Add(produto);
        Context.SaveChanges();
        return CreatedAtAction(nameof(BuscarProdutoPorId), new { id = produto.Id }, produto);
    }

    /// <summary>
    /// Lista todos os produtos do banco de dados
    /// </summary>
    /// <param name="skip">Método que pula a leitura de derterminado número de registros.</param>
    /// <param name="take">Método que determina a quantidade de registros que serão lidos por página</param>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Caso requisição seja feita com sucesso</response>
    [HttpGet]
    public IEnumerable<ReadProdutoDto> ListarProdutos([FromQuery] int skip = 0, int take = 5)
    {
        return Mapper.Map<List<ReadProdutoDto>>(Context.Produtos.Skip(skip).Take(take));
    }

    /// <summary>
    /// Lê um produto do banco de dados indicado pelo Id
    /// </summary>
    /// <param name="id">Indica o id do produto a ser lido</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso leitura seja feita com sucesso</response>
    [HttpGet("{id}")]
    public IActionResult BuscarProdutoPorId(int id)
    {
        var produto = Context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        var produtoDto = Mapper.Map<ReadProdutoDto>(produto);
        return Ok(produtoDto);
    }

    /// <summary>
    /// Atualiza todas as propriedades de um produto do banco de dados indicado pelo Id
    /// </summary>
    /// <param name="id">Indica o id do produto a ser atualizado</param>
    /// <param name="produtoDto">Objeto com os campos necessários para atualização de um produto</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso atualização seja feita com sucesso</response>
    [HttpPut("{id}")]
    public IActionResult AtualizarProduto(int id, [FromBody] UpdateProdutoDto produtoDto)
    {
        var produto = Context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        Mapper.Map(produtoDto, produto);
        Context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Atualiza uma ou mais propriedades de um produto do banco de dados indicado pelo Id
    /// </summary>
    /// <param name="id">Indica o id do produto a ser atualizado</param>
    /// <param name="patch">Comtém uma ou mais informações do produto a ser atualizado</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso atualização seja feita com sucesso</response>
    [HttpPatch("{id}")]
    public IActionResult AtualizarProdutoParcial(int id, JsonPatchDocument<UpdateProdutoDto> patch)
    {
        var produto = Context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();

        var produtoParaAtualizar = Mapper.Map<UpdateProdutoDto>(produto);
        
        patch.ApplyTo(produtoParaAtualizar, ModelState);

        if (!TryValidateModel(produtoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        Mapper.Map(produtoParaAtualizar, produto);
        Context.SaveChanges();
        return NoContent();
    }

    /// <summary>
    /// Deleta um produto do banco de dados indicado pelo Id
    /// </summary>
    /// <param name="id">Indica o id do produto a ser deletado</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso deleção seja feita com sucesso</response>
    [HttpDelete("{id}")]
    public IActionResult DeletarProduto(int id)
    {
        var produto = Context.Produtos.FirstOrDefault(produto => produto.Id == id);
        if (produto == null) return NotFound();
        Context.Remove(produto);
        Context.SaveChanges();
        return NoContent();
    }
}
