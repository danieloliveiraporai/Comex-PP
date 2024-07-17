using AutoMapper;
using ComexAPI.Data;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace ComexAPI.Controllers;

[ApiController]
[Route("[controller]")]
public class ClienteController : ControllerBase
{
    private ProdutoContext Context;
    private IMapper Mapper;

    public ClienteController(ProdutoContext context, IMapper mapper)
    {
        Context = context;
        Mapper = mapper;
    }

    [HttpPost]
    public IActionResult AdicionarCliente([FromBody] CreateClienteDto clienteDto)
    {
        Cliente cliente = Mapper.Map<Cliente>(clienteDto);
        Context.Clientes.Add(cliente);
        Context.SaveChanges();
        return CreatedAtAction(nameof(BuscarClientePorId), new { id = cliente.Id }, cliente);
    }

    
    [HttpGet]
    public IEnumerable<ReadClienteDto> ListarClientes([FromQuery] int skip = 0, int take = 5)
    {
        var listaDeClientes = Mapper.Map<List<ReadClienteDto>>(Context.Clientes.Skip(skip).Take(take));
        return listaDeClientes;
    }

    
    [HttpGet("{id}")]
    public IActionResult BuscarClientePorId(int id)
    {
        var cliente = Context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        var clienteDto = Mapper.Map<ReadClienteDto>(cliente);
        return Ok(clienteDto);
    }

    
    [HttpPut("{id}")]
    public IActionResult AtualizarCliente(int id, [FromBody] UpdateClienteDto clienteDto)
    {
        var cliente = Context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        Mapper.Map(clienteDto, cliente);
        Context.SaveChanges();
        return NoContent();
    }

    
    [HttpPatch("{id}")]
    public IActionResult AtualizarClienteParcial(int id, JsonPatchDocument<UpdateClienteDto> patch)
    {
        var cliente = Context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();

        var clienteParaAtualizar = Mapper.Map<UpdateClienteDto>(cliente);

        patch.ApplyTo(clienteParaAtualizar, ModelState);

        if (!TryValidateModel(clienteParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        Mapper.Map(clienteParaAtualizar, cliente);
        Context.SaveChanges();
        return NoContent();
    }

    
    [HttpDelete("{id}")]
    public IActionResult DeletarCliente(int id)
    {
        var cliente = Context.Clientes.FirstOrDefault(cliente => cliente.Id == id);
        if (cliente == null) return NotFound();
        Context.Remove(cliente);
        Context.SaveChanges();
        return NoContent();
    }
}

