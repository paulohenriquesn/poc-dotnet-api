using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace MinhaApi;

public record class ProdutoDTO
{
    [BindNever]
    public int Id {get; set; }
    public string Nome {get; set;}
    
    [JsonPropertyName("image_url")]
    public string ImagemUrl {get; set;}


    [JsonPropertyName("category_id")]
    public int CategoriaId {get; set; }

}
