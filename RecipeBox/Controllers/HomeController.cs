using Microsoft.AspNetCore.Mvc;
using RecipeBox.Models;
using System.Collections.Generic;
using System.Linq;

namespace RecipeBox.Controllers
{
    public class HomeController : Controller
    {
      private readonly RecipeBoxContext _db;

      public HomeController(RecipeBoxContext db)
      {
        _db = db;
      }

      [HttpGet("/")]
      public ActionResult Index()
      {
        Recipe[] recipes = _db.Recipes.ToArray();
        Dictionary<string,object[]> model = new Dictionary<string, object[]>();
        model.Add("recipes", recipes);
        return View(model);
      }
    }
}