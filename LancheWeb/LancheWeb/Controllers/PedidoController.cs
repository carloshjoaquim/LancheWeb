using LancheWeb.Business.BLL;
using LancheWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace LancheWeb.Controllers
{
    public class PedidoController : Controller
    {
        /*
          1. Exibir lanches do cardápio.
          2. Selecionar Lanche.
          3. Alterar ingredientes Lanche.
             3.1. Incluir novo Lanche.
          4. Finalizar Pedido.
        */

        public ActionResult Index()
        {
            // 1. Exibir Cardábio de Lanches.            
            var lanches = LancheBLL.ListaCompleto();
            ViewBag.Lanches = lanches;

            return View(lanches);
        }

        public ActionResult DetalheLanche(Lanche lanche)
        {
            // 2.Selecionar Lanche
            lanche.IngredienteLanches = IngredienteLancheBLL.BuscaPorLancheId(lanche.LancheId);

            return View(lanche);
        }

        public ActionResult ResumoPedido(Lanche lanche)
        {
            var model = PedidoBLL.MontaResumo(lanche);

            return View(model);
        }      

        public ActionResult EscolherIngrediente(Lanche lanche)
        {
            // 3.Alterar ingredientes Lanche.
            ViewBag.Lanche = lanche;
            var ingredientesDisponiveis = IngredienteBLL.ListaIngredientes().Where(i => i.Quantidade > 0);

            return View(ingredientesDisponiveis);
        }
      

    }
}
