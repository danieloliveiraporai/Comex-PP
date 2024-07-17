using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class EnderecoController : ControllerBase
{
    private ProdutoContext Context;
    private IMapper Mapper;

    public EnderecoController(ProdutoContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarEndereco([FromBody] CreateEnderecoDto enderecoDto)
    {
        Endereco endereco = Mapper.Map<Endereco>(enderecoDto);
        Context.Enderecos.Add(endereco);
        Context.SaveChanges();
        return CreatedAtAction(nameof(BuscarEnderecoPorId), new { id = endereco.Id }, endereco);
    }
        
    [HttpGet]
    public IEnumerable<ReadEnderecoDto> ListarEndereco([FromQuery] int skip = 0, int take = 5)
    {
        return Mapper.Map<List<ReadEnderecoDto>>(Context.Enderecos.Skip(skip).Take(take));
    }

    
    [HttpGet("{id}")]
    public IActionResult BuscarEnderecoPorId(int id)
    {
        var endereco = Context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        var enderecoDto = Mapper.Map<ReadEnderecoDto>(endereco);
        return Ok(enderecoDto);
    }

    
    [HttpPut("{id}")]
    public IActionResult AtualizarEndereco(int id, [FromBody] UpdateEnderecoDto enderecoDto)
    {
        var endereco = Context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        Mapper.Map(enderecoDto, endereco);
        Context.SaveChanges();
        return NoContent();
    }

    
    [HttpPatch("{id}")]
    public IActionResult AtualizarEnderecoParcial(int id, JsonPatchDocument<UpdateEnderecoDto> patch)
    {
        var endereco = Context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();

        var enderecoParaAtualizar = Mapper.Map<UpdateEnderecoDto>(endereco);

        patch.ApplyTo(enderecoParaAtualizar, ModelState);

        if (!TryValidateModel(enderecoParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        Mapper.Map(enderecoParaAtualizar, endereco);
        Context.SaveChanges();
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public IActionResult DeletarEndereco(int id)
    {
        var endereco = Context.Enderecos.FirstOrDefault(endereco => endereco.Id == id);
        if (endereco == null) return NotFound();
        Context.Remove(endereco);
        Context.SaveChanges();
        return NoContent();
    }
}

