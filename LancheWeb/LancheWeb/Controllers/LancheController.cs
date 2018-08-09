using LancheWeb.DAO;
using LancheWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancheWeb.Controllers
{
    public class LancheController : Controller
    {
        // GET: Produto
        [Route("lanche", Name = "ListaLanches")]
        public ActionResult Index()
        {
            var dao = new LanchesDAO();
            var lanches = dao.Lista();
            ViewBag.Lanches = lanches;

            return View(lanches);
        }

        public ActionResult Cadastrar()
        {
            var dao = new IngredientesDAO();
            ViewBag.Ingredientes = dao.Lista();
            ViewBag.Lanches = new Lanche();


            return View();
        }

        [HttpPost]
        public JsonResult Incluir(Lanche lanche)
        {
       
            if (ModelState.IsValid)
            {
                var dao = new LanchesDAO();
                dao.Adiciona(lanche);

                return Json("Adicionado");
            }
            else
            {
                ViewBag.Lanche = lanche;

                return Json("Erro");
            }
        }

        [Route("detalhe/{id}", Name = "DetalheLanche")]
        public ActionResult Detalhe(int id)
        {
            var ingrediente = new IngredientesDAO().BuscaPorId(id);
            ViewBag.Ingrediente = ingrediente;

            return View(ingrediente);
        }

        public ActionResult Editar(Ingrediente ingrediente)
        {
            return View(ingrediente);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult EditaIngrediente(Ingrediente ingrediente)
        {

            var dao = new IngredientesDAO();
            dao.Atualiza(ingrediente);

            return RedirectToAction("Index");
        }

        public ActionResult Excluir(Lanche lanche)
        {
            var dao = new LanchesDAO();
            dao.Remove(lanche);

            return RedirectToAction("Index");

        }



    }
}
