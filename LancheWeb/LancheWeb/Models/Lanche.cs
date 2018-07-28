using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace LancheWeb.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        public int IdLanche { get; set; }
        public string Nome { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }        


        public decimal getValorLanche()
        {
            return Ingredientes.Sum(i => i.Valor);
        }
    }
}
