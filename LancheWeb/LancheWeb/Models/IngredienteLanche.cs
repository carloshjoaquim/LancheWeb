namespace LancheWeb.Models
{
    public class IngredienteLanche
    {
        public IngredienteLanche(int idLanche, int idIngrediente)
        {
            this.idLanche = idLanche;
            this.idIngrediente = idIngrediente;
        }

        public int Id { get; set; }
        public int idLanche { get; set; }
        public int idIngrediente { get; set; }
    }
}
