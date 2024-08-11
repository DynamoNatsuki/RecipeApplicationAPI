using RecipeApplicationAPI.Models;

namespace RecipeApplicationAPI.ViewModels
{
    public class RecipeViewModel
    {
        public string Id { get; set; }
        public string Title { get; set; }
        public string Instructions { get; set; }

        public RecipeViewModel(Recipe recipe) 
        {
            Id = recipe.Id.ToString();
            Title = recipe.Title;
            Instructions = recipe.Instructions;
        }

    }
}
