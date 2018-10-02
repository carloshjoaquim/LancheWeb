using LancheWeb.Data.DAO;
using LancheWeb.Models.Models;
using System.Collections.Generic;
using System.Linq;

namespace LancheWeb.Business.BLL
{
    public class LancheBLL
    {

        public static IEnumerable<Lanche> ListarLanches()
        {
            var dao = new LanchesDAO();
            return dao.Lista();
        }

        public static void AdicionarLanche(Lanche lanche)
        {
            var dao = new LanchesDAO();
            dao.Adiciona(lanche);
        }

        public static void AtualizarLanche(Lanche lanche)
        {
            var dao = new LanchesDAO();
            dao.Atualiza(lanche);
        }

        public static void ExcluirLanche(Lanche lanche)
        {
            var ingredientesLanche = ListaIngredientesByIdLanche(lanche.LancheId);
            var ildao = new IngredienteLancheDAO();
            var lanchedao = new LanchesDAO();

            foreach (var item in ingredientesLanche)
            {
                ildao.Remove(item);
            }

            lanchedao.Remove(lanche);
        }

        public static List<Ingrediente> EditarLanche(Lanche lanche)
        {
            var ingredientes = new IngredientesDAO().Lista();
            var ingredientesLanche = ListaIngredientesByIdLanche(lanche.LancheId);
            var listIngredientes = new List<Ingrediente>();

            foreach (var item in ingredientes)
            {
                listIngredientes.Add(
                                 new Ingrediente
                                 {
                                     IngredienteId = item.IngredienteId,
                                     Nome = item.Nome,
                                     Valor = item.Valor,
                                     Quantidade = ingredientesLanche.
                                                  FirstOrDefault(x => x.IdIngrediente == item.IngredienteId) != null ?
                                                  ingredientesLanche.
                                                  FirstOrDefault(x => x.IdIngrediente == item.IngredienteId).Quantidade :
                                                  0
                                 }
                    );
            }

            return listIngredientes;
        }

        public static List<IngredienteLanche> ListaIngredientesByIdLanche(int idLanche)
        {
            return new IngredienteLancheDAO().BuscaPorLancheId(idLanche);
        }

        public static IList<Lanche> ListaCompleto()
        {
            var dao = new LanchesDAO();
            return dao.ListaCompleto();
         }
       
    }
}
