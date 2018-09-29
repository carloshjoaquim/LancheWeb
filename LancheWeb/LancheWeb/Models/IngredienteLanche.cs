using Newtonsoft.Json;

namespace LancheWeb.Models
{
    public class IngredienteLanche
    {
        [JsonProperty(PropertyName = "IdLanche")]
        public int IdLanche { get; set; }
        [JsonProperty(PropertyName = "Lanche")]
        public Lanche Lanche { get; set; }

        [JsonProperty(PropertyName = "IdIngrediente")]
        public int IdIngrediente { get; set; }
        [JsonProperty(PropertyName = "Ingrediente")]
        public Ingrediente Ingrediente { get; set; }

        [JsonProperty(PropertyName = "Quantidade")]
        public int Quantidade { get; set; }
    }


}
