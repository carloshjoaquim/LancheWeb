using System.Collections.Generic;
using System.Linq;

namespace LancheWeb.Models
{
    public class Lanche
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }        


        public decimal getValorLanche()
        {
            return Ingredientes.Sum(i => i.Valor);
        }
    }
}
