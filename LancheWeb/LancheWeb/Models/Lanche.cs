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
        public virtual decimal Valor {get; set;}
        public ICollection<IngredienteLanche> IngredienteLanches { get; set; }


        public decimal GetValorLanche()
        {
            Valor = 0;

            foreach (var IngLanche in IngredienteLanches)
            {
                Valor += IngLanche.Ingrediente.Valor * IngLanche.Quantidade;
            }

            return Valor;
        }
        
    }
}
