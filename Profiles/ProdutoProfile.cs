using AutoMapper;
using MinhaApi.Domain.Entities;

namespace MinhaApi;

public class ProdutoProfile : Profile
{
    public ProdutoProfile()
    {
        CreateMap<Produto, ProdutoDTO>();
        CreateMap<ProdutoDTO, Produto>();
    }
}
