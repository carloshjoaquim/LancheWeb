using LancheWeb.Data.DAO;
using LancheWeb.Models.Models;
using System.Collections.Generic;

namespace LancheWeb.Business.BLL
{
    public class IngredienteLancheBLL
    {

        public void AdicionarIngredientes(IEnumerable<IngredienteLanche> ingredientes)
        {
            foreach (var il in ingredientes)
            {
                var dao = new IngredienteLancheDAO();
                dao.Adiciona(il);
            }
        }

        public Ingrediente BuscarPorId(int id)
        {
          return  new IngredientesDAO().BuscaPorId(id);
        }

        public void EditarIngredienteLanche(IEnumerable<IngredienteLanche> ingredientes)
        {
            var dao = new IngredienteLancheDAO();
            foreach (var item in ingredientes)
            {
                if (dao.BuscaPorId(item.IdIngrediente, item.IdLanche) != null)
                    dao.Atualiza(item);
                else
                    dao.Adiciona(item);
            }
        }

        public List<IngredienteLanche> BuscaPorLancheId(int id)
        {
            var dao = new IngredienteLancheDAO();
            return dao.BuscaPorLancheId(id);
        }




    }
}
