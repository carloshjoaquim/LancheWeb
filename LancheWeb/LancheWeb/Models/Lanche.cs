using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancheWeb.Models
{
    public class Lanche
    {
        public int IdLanche { get; set; }
        public string Nome { get; set; }
        public decimal ValorFinal { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
    }
}
