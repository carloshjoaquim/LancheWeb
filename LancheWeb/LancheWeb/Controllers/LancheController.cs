using LancheWeb.Business.BLL;
using LancheWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancheWeb.Controllers
{
    public class LancheController : Controller
    {
        // GET: Produto
        [Route("lanche", Name = "ListaLanches")]
        public ActionResult Index()
        {
            var lanches = LancheBLL.ListarLanches();
            ViewBag.Lanches = lanches;

            return View(lanches);
        }

        public ActionResult Cadastrar()
        {
            ViewBag.Ingredientes = IngredienteBLL.ListaIngredientes();
            ViewBag.Lanches = new Lanche();

            return View();
        }

        [HttpPost]
        public JsonResult Incluir(Lanche lanche)
        {

            if (ModelState.IsValid)
            {
                LancheBLL.AdicionarLanche(lanche);
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
            var listIngredientes = LancheBLL.EditarLanche(lanche);

            ViewBag.Ingredientes = listIngredientes;

            return View(lanche);
        }

        [HttpPut]
        public JsonResult EditaLanche(Lanche lanche)
        {            
            LancheBLL.AtualizarLanche(lanche);
            return Json(new { lanche.LancheId });
        }

        public ActionResult Excluir(Lanche lanche)
        {
            LancheBLL.ExcluirLanche(lanche);
            return RedirectToAction("Index");
        }

    }
}
