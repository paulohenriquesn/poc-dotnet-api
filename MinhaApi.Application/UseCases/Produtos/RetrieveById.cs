using MinhaApi.Domain;
using MinhaApi.Domain.Entities;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

namespace MinhaApi.Application.UseCases.Produtos;

public class RetrieveById : IRetrieveById
{
    private IUnitOfWork _unitRepository;
    public RetrieveById(IUnitOfWork unitRepository) {
        _unitRepository = unitRepository;
    }
    
    public async Task<Produto> Handler(int Id) {
        return await _unitRepository.ProdutoRepository.getById(Id);
    }
}
