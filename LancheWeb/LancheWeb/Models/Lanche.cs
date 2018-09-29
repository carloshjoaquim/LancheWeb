using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LancheWeb.Models
{
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }
        public string Nome { get; set; }
        public ICollection<IngredienteLanche> IngredienteLanches { get; set; }


        public decimal GetValorLanche()
        {
            decimal valorLanche = 0;

            foreach (var IngLanche in IngredienteLanches)
            {
                valorLanche += IngLanche.Ingrediente.Valor * IngLanche.Quantidade;
            }

            return valorLanche;
        }
        
    }
}
