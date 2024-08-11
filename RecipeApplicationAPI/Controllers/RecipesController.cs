using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RecipeApplicationAPI.ViewModels;

namespace RecipeApplicationAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipesController : ControllerBase
    {
        [HttpGet(Name = "GetRecipes")]
        public async Task<IEnumerable<RecipeViewModel>> Get()
        {
            var db = new Database();
            var recipes = await db.GetRecipes();

            var viewModel = new List<RecipeViewModel>();

            foreach (var recipe in recipes)
            {
                viewModel.Add(new RecipeViewModel(recipe));
            }

            return viewModel;
        }

        [HttpGet("{id}", Name = "GetRecipeById")]
        public async Task<RecipeViewModel> GetById(string id)
        {
            var db = new Database();
            var recipe = await db.GetRecipe(id);

            var viewModel = new RecipeViewModel(recipe);
            return viewModel;
        }

        [HttpPost(Name = "PostRecipe")]
        public async Task<IActionResult> Post(string title, string instructions)
        {
            var db = new Database();
            await db.SaveRecipe(title, instructions);

            return Ok();
        }

        [HttpDelete("{id}", Name = "DeleteRecipe")]
        public async Task<IActionResult> DeleteById(string id)
        {
            var db = new Database();
            await db.DeleteRecipe(id);

            return Ok();
        }

        [HttpPut("{id}", Name = "PutRecipe")]
        public async Task<IActionResult> PutRecipe(string id, string title, string instructions)
        {
            var db = new Database();
            await db.UpdateRecipe(id, title, instructions);

            return Ok();
        }
    }
}
