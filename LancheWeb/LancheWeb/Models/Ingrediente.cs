using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LancheWeb.Models
{
    public class Ingrediente
    {
        public int IdIngrediente { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
