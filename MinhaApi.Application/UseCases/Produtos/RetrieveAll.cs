using System.Collections;
using MinhaApi.Domain;
using MinhaApi.Domain.Entities;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

namespace MinhaApi.Application.UseCases.Produtos;

public class RetrieveAll : IRetrieveAll
{
    private IUnitOfWork _unitRepository;
    public RetrieveAll(IUnitOfWork unitRepository) {
        _unitRepository = unitRepository;
    }
    
    public async Task<IEnumerable<Produto>> Handler() {
        return await _unitRepository.ProdutoRepository.List();
    }
}
