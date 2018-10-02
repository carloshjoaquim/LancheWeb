using LancheWeb.Data.DAO;
using LancheWeb.Models.Models;
using System.Collections.Generic;

namespace LancheWeb.Business.BLL
{
    public class IngredienteBLL
    {
        public static IEnumerable<Ingrediente> ListaIngredientes()
        {
            var dao = new IngredientesDAO();
            var ingredientes = dao.Lista();
            return ingredientes;
        }

        public static void AdicionaIngrediente(Ingrediente ingrediente)
        {
            IngredientesDAO dao = new IngredientesDAO();
            dao.Adiciona(ingrediente);
        }

        public static Ingrediente BuscaIngredientePorId(int id)
        {
          return new IngredientesDAO().BuscaPorId(id);
        }

        public static void AtualizaIngrediente(Ingrediente ingrediente)
        {
            var dao = new IngredientesDAO();
            dao.Atualiza(ingrediente);
        }

        public static void RemoverIngrediente(Ingrediente ingrediente)
        {
            var dao = new IngredientesDAO();
            dao.Remove(ingrediente);
        }

    }
}
