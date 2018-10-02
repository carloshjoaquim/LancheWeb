using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace LancheWeb.Models.Models
{
    public class Ingrediente
    {
        [Key]
        public int IngredienteId { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public ICollection<IngredienteLanche> IngredienteLanches { get; set; }
    }
}
