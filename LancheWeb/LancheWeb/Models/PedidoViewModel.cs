using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace LancheWeb.Models
{
    public class PedidoViewModel
    {
      
        public int LancheId { get; set; }
        public string Nome { get; set; }
        public virtual decimal ValorLanche {get; set;}
        public virtual decimal ValorPedido { get; set; }
        public List<Ingrediente> Ingredientes { get; set; }
        public List<Promocao> Promocoes { get; set; }
             
    }
}
