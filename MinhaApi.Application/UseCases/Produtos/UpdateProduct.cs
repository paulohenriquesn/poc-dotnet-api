using MinhaApi.Domain;
using MinhaApi.Domain.Entities;

namespace MinhaApi.Application;

public class UpdateProduct : IUpdateProduct
{
    private readonly IUnitOfWork _unitRepository;

    public UpdateProduct(IUnitOfWork unitRepository)
    {
        _unitRepository = unitRepository;
    }

    public async Task Handler(int Id, Produto product) {
        await _unitRepository.ProdutoRepository.Update(Id, product);
        await _unitRepository.Commit();
    }
}
