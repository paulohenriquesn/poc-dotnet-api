using MinhaApi.Domain.Entities;

namespace MinhaApi.Domain;

public class CreateProduct : ICreateProduct
{
    private IUnitOfWork _unitRepository;
    public CreateProduct(IUnitOfWork unitRepository) {
        _unitRepository = unitRepository;
    }

    public async Task Handler(Produto product) {
        await _unitRepository.ProdutoRepository.Save(product);
        await _unitRepository.Commit();
    }
}
