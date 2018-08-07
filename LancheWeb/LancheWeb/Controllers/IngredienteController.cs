using LancheWeb.DAO;
using LancheWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancheWeb.Controllers
{
    public class IngredienteController : Controller
    {
        // GET: Produto
        [Route("ingredientes", Name = "ListaIngredientes")]
        public ActionResult Index()
        {
            var dao = new IngredientesDAO();
            var ingredientes = dao.Lista();
            ViewBag.Ingredientes = ingredientes;

            return View(ingredientes);
        }

        public ActionResult Cadastrar()
        {
            var dao = new IngredientesDAO();
            ViewBag.Ingredientes = new Ingrediente();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(Ingrediente ingrediente)
        {
       

            if (ModelState.IsValid)
            {
                IngredientesDAO dao = new IngredientesDAO();
                dao.Adiciona(ingrediente);

                return RedirectToAction("Index");
            }
            else
            {
                ViewBag.Ingrediente = ingrediente;

                return View("Cadastrar");
            }
        }

        [Route("detalhe/{id}", Name = "DetalheIngrediente")]
        public ActionResult Detalhe(int id)
        {
            var ingrediente = new IngredientesDAO().BuscaPorId(id);
            ViewBag.Ingrediente = ingrediente;

            return View(ingrediente);
        }

       

    }
}
