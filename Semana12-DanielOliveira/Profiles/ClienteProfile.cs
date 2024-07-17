using AutoMapper;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;

namespace ComexAPI.Profiles
{
    public class ClienteProfile : Profile
    {
        public ClienteProfile()
        {
            CreateMap<CreateClienteDto, Cliente>();
            CreateMap<Cliente, ReadClienteDto>().ForMember(clienteDto => clienteDto.ReadEnderecoDto, options => options.MapFrom(cliente => cliente.Endereco));
            CreateMap<UpdateClienteDto, Cliente>();
        }
    }
}
