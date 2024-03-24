using AutoMapper;
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
    private readonly IMapper _mapper;

    public ProdutosController(
        ILogger<ProdutosController> log,
        IMapper mapper) {
        _mapper = mapper;
        _log = log;
    }

    [HttpGet("produtos")]
    public async Task<ActionResult<IEnumerable<ProdutoDTO>>> RetrieveAll(IRetrieveAll UseCase) {
        _log.LogInformation("Retrieve all Produtos");
        var products = await UseCase.Handler();
        if (products == null) {
            return NotFound();
        }
        return Ok(products);
    }

    [HttpGet("produtos/{id}")]
    public async Task<ActionResult<ProdutoDTO>> RetrieveById(IRetrieveById UseCase, int id) {
        _log.LogInformation($"Retrieve Produto ${id} By Id");
        var product = await UseCase.Handler(id);
        
        if(product == null) {
            return NotFound();
        }
        var mappedProductDto = _mapper.Map<ProdutoDTO>(product);
        return Ok(mappedProductDto);
    }

    [HttpPost("produtos")]
    public async Task<IActionResult> Save(ICreateProduct UseCase, [FromBody] ProdutoDTO product) {
        try {
        var mappedProduct = _mapper.Map<Produto>(product);
        await UseCase.Handler(mappedProduct);
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
