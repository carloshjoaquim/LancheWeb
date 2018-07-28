using System.ComponentModel.DataAnnotations.Schema;

namespace LancheWeb.Models
{
    [Table("Ingredientes")]
    public class Ingrediente
    {
        public int IdIngrediente { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
