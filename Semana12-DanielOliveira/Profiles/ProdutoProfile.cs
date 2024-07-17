using AutoMapper;
using ComexAPI.Data.Dtos;
using ComexAPI.Models;

namespace ComexAPI.Profiles;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<CreateProdutoDto, Produto>();                
        CreateMap<Produto, ReadProdutoDto>();
        CreateMap<UpdateProdutoDto, Produto>();
        CreateMap<Produto, UpdateProdutoDto>();
    }
}
