namespace MinhaApi.Domain;

public interface IUnitOfWork
{

    IProdutoRepository ProdutoRepository { get; }
    Task Commit();

}
