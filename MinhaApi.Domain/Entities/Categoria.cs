using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace MinhaApi.Domain.Entities;

public class Categoria
{
    public Categoria() {
        this.Produtos = new Collection<Produto>();
    }

    [Key]
    public int CategoriaId {get; set; }

    [Required]
    public string? Nome {get; set; }

    [Required]
    public string? ImagemUrl {get; set; }

    public ICollection<Produto>? Produtos {get; set; }

}
