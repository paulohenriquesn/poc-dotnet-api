using Microsoft.AspNetCore.Mvc;
using MinhaApi.Application.UseCases.Produtos;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api")]
public class ProdutosController : ControllerBase
{
    private readonly IRetrieveAll _RetrieveAllUseCase;
    private readonly ILogger<ProdutosController> _log;

    public ProdutosController(ILogger<ProdutosController> log, IRetrieveAll RetrieveAllUseCase) {
        _RetrieveAllUseCase = RetrieveAllUseCase;
        _log = log;
    }

    [HttpGet("produtos")]
    public async Task<IActionResult> RetrieveAll() {
        _log.LogInformation("Retrieve all Produtos");
        var products = await _RetrieveAllUseCase.Handler();
        if (products == null) {
            return NotFound();
        }
        return Ok(products);
    }
}
