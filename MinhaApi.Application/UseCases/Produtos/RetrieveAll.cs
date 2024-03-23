using System.Collections;
using MinhaApi.Domain;
using MinhaApi.Domain.Entities;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

namespace MinhaApi.Application.UseCases.Produtos;

public class RetrieveAll : IRetrieveAll
{
    private IProdutoRepository _produtoRepository;
    public RetrieveAll(IProdutoRepository produtoRepository) {
        _produtoRepository = produtoRepository;
    }
    
    public async Task<IEnumerable<Produto>> Handler() {
        return await _produtoRepository.List();
    }
}
