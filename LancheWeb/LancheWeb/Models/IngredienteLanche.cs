using System.ComponentModel.DataAnnotations;

namespace LancheWeb.Models
{
    public class IngredienteLanche
    {

        public int IdLanche { get; set; }
        public Lanche Lanche { get; set; }

        public int IdIngrediente { get; set; }
        public Ingrediente Ingrediente { get; set; }
    }
}
