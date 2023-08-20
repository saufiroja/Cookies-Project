using CookiesBook.Recipes;
using CookiesBook.Recipes.Ingredients;

namespace CookiesBook.App;

public interface IRecipesUserInteraction
{
    void Exit();
    void PrintExistingRecipes(IEnumerable<Recipe> allRecipes);
    void PromptToCreateNewRecipe();
    IEnumerable<Ingredient> ReadIngredientsFromUser();
    void ShowMessage(string message);
}
