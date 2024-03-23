using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Domain.Entities;

public class Produto
{
    [Key]
    public int ProdutoId {get; set; }
    [Required]
    public string? Nome {get; set; }
    [Required]
    public string? ImagemUrl {get; set;}
    [Required]
    public float Estoque {get; set;}
    [Required]
    public DateTime DataCadastro {get; set;}
    [Required]
    public int CategoriaId {get; set;}
    public Categoria Categoria {get; set; }
}
