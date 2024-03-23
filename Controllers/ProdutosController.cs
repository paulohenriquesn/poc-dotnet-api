using Microsoft.AspNetCore.Mvc;
using MinhaApi.Application.UseCases.Produtos;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api")]
public class ProdutosController : ControllerBase
{
    private readonly IRetrieveAll _RetrieveAllUseCase;
    private readonly IRetrieveById _RetrieveByIdUseCase;
    private readonly ILogger<ProdutosController> _log;

    public ProdutosController(
        ILogger<ProdutosController> log, 
        IRetrieveAll RetrieveAllUseCase,
        IRetrieveById RetrieveByIdUseCase) {
        _RetrieveAllUseCase = RetrieveAllUseCase;
        _RetrieveByIdUseCase = RetrieveByIdUseCase;

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

    [HttpGet("produtos/{id}")]
    public async Task<IActionResult> RetrieveById(int id) {
        _log.LogInformation($"Retrieve Produto ${id} By Id");
        var product = await _RetrieveByIdUseCase.Handler(id);
        
        if(product == null) {
            return NotFound();
        }

        return Ok(product);
    }
}   
