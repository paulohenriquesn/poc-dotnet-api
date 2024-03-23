using MinhaApi.Domain;
using MinhaApi.Domain.Entities;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

namespace MinhaApi.Application.UseCases.Produtos;

public class RetrieveById : IRetrieveById
{
    private IProdutoRepository _produtoRepository;
    public RetrieveById(IProdutoRepository produtoRepository) {
        _produtoRepository = produtoRepository;
    }
    
    public async Task<Produto> Handler(int Id) {
        return await _produtoRepository.getById(Id);
    }
}
