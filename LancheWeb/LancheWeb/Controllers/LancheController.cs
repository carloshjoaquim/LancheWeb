using LancheWeb.Business.BLL;
using LancheWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancheWeb.Controllers
{
    public class LancheController : Controller
    {
        private readonly IngredienteBLL ingredienteBLL = new IngredienteBLL();
        private readonly LancheBLL lancheBLL = new LancheBLL();

        // GET: Produto
        [Route("lanche", Name = "ListaLanches")]
        public ActionResult Index()
        {
            var lanches = lancheBLL.ListarLanches();
            ViewBag.Lanches = lanches;

            return View(lanches);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.Ingredientes = ingredienteBLL.ListaIngredientes();
            ViewBag.Lanches = new Lanche();

            return View();
        }

        [HttpPost]
        public JsonResult Incluir(Lanche lanche)
        {

            if (ModelState.IsValid)
            {
                lancheBLL.AdicionarLanche(lanche);
                return Json(new { lanche.LancheId });
            }
            else
            {
                ViewBag.Lanche = lanche;
                return Json("Erro");
            }
        }


        public ActionResult Editar(Lanche lanche)
        {
            var listIngredientes = lancheBLL.EditarLanche(lanche);

            ViewBag.Ingredientes = listIngredientes;

            return View(lanche);
        }

        [HttpPut]
        public JsonResult EditaLanche(Lanche lanche)
        {
            lancheBLL.AtualizarLanche(lanche);
            return Json(new { lanche.LancheId });
        }

        public ActionResult Excluir(Lanche lanche)
        {
            lancheBLL.ExcluirLanche(lanche);
            return RedirectToAction("Index");
        }

    }
}
