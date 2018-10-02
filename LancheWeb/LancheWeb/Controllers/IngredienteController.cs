using LancheWeb.Business.BLL;
using LancheWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;

namespace LancheWeb.Controllers
{
    public class IngredienteController : Controller
    {
        private readonly IngredienteBLL ingredienteBLL = new IngredienteBLL();

        // GET: Produto
        [Route("ingredientes", Name = "ListaIngredientes")]
        public ActionResult Index()
        {
            var ingredientes = ingredienteBLL.ListaIngredientes();
            ViewBag.Ingredientes = ingredientes;

            return View(ingredientes);
        }
    
        public ActionResult Cadastrar()
        {
            ViewBag.Ingredientes = new Ingrediente();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Incluir(Ingrediente ingrediente)
        {
      
            if (ModelState.IsValid)
            {
                ingredienteBLL.AdicionaIngrediente(ingrediente);

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
            var ingrediente = ingredienteBLL.BuscaIngredientePorId(id);
            ViewBag.Ingrediente = ingrediente;

            return View(ingrediente);
        }

        public ActionResult Editar(Ingrediente ingrediente)
        {
            return View(ingrediente);
        }

        [HttpPut]
        [ValidateAntiForgeryToken]
        public ActionResult EditaIngrediente(Ingrediente ingrediente)
        {
            ingredienteBLL.AtualizaIngrediente(ingrediente);
            return RedirectToAction("Index");
        }

        public ActionResult Excluir(Ingrediente ingrediente)
        {
            ingredienteBLL.RemoverIngrediente(ingrediente);
            return RedirectToAction("Index");
        }

    }
}
