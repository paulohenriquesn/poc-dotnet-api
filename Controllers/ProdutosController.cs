using Microsoft.AspNetCore.Mvc;
using MinhaApi.Domain;
using MinhaApi.Domain.Entities;
using MinhaApi.MinhaApi.Domain.UseCases.Produtos;

namespace MinhaApi.Controllers;

[ApiController]
[Route("api")]
public class ProdutosController : ControllerBase
{
    private readonly ILogger<ProdutosController> _log;

    public ProdutosController(
        ILogger<ProdutosController> log) {
        _log = log;
    }

    [HttpGet("produtos")]
    public async Task<IActionResult> RetrieveAll(IRetrieveAll UseCase) {
        _log.LogInformation("Retrieve all Produtos");
        var products = await UseCase.Handler();
        if (products == null) {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpGet("produtos/{id}")]
    public async Task<IActionResult> RetrieveById(IRetrieveById UseCase, int id) {
        _log.LogInformation($"Retrieve Produto ${id} By Id");
        var product = await UseCase.Handler(id);
        
        if(product == null) {
            return NotFound();
        }

        return Ok(product);
    }

    [HttpPost("produtos")]
    public async Task<IActionResult> Save(ICreateProduct UseCase, [FromBody] Produto product) {
        try {
        await UseCase.Handler(product);
        return Created();
        }catch {
            return UnprocessableEntity();
        }
    }

    [HttpDelete("produtos/{id}")]
    public async Task<IActionResult> Delete(IDeleteProduct UseCase, int id) {
        try {
        await UseCase.Handler(id);
        return Ok();
        }catch {
            return UnprocessableEntity();
        }
    }

    [HttpPut("produtos/{id}")]
    public async Task<IActionResult> Update(IUpdateProduct UseCase, int id, [FromBody] Produto product) {
        try {
        await UseCase.Handler(id, product);
        return Ok();
        }catch {
            return UnprocessableEntity();
        }
    }
}   
