using LancheWeb.Business.BLL;
using LancheWeb.Models.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LancheWeb.Controllers
{
    public class IngredienteLancheController : Controller
    {
        private readonly IngredienteLancheBLL ingredienteLancheBLL = new IngredienteLancheBLL();


        [HttpPost]
        public JsonResult Incluir([FromBody] IEnumerable<IngredienteLanche> ingredientes)
        {
            ingredienteLancheBLL.AdicionarIngredientes(ingredientes);
            return Json("OK");
        }

        [Route("detalhe/{id}", Name = "DetalheIngrediente")]
        public ActionResult Detalhe(int id)
        {
            var ingrediente = ingredienteLancheBLL.BuscarPorId(id);
            ViewBag.Ingrediente = ingrediente;

            return View(ingrediente);
        }

        public ActionResult Editar(Ingrediente ingrediente)
        {
            return View(ingrediente);
        }

        [HttpPut]
        public JsonResult EditaIngredienteLanche([FromBody]IEnumerable<IngredienteLanche> ingredientes)
        {
            ingredienteLancheBLL.EditarIngredienteLanche(ingredientes);

            return Json("OK");
        }
    }
}
