using CookiesBook.Recipes.Ingredients;
using CookiesBook.DataAccess;

namespace CookiesBook.Recipes;

public class RecipesRepository : IRecipesRepository
{
    private readonly IStringsRepository _stringsRepository;
    private readonly IIngredientsRegister _ingredientsRegister;
    private const string Separator = ",";

    public RecipesRepository(IStringsRepository stringsRepository, IIngredientsRegister ingredientsRegister)
    {
        _stringsRepository = stringsRepository;
        _ingredientsRegister = ingredientsRegister;
    }

    public List<Recipe> Read(string filepath)
    {
        List<string> recipesFromFile = _stringsRepository.Read(filepath);
        var allRecipes = new List<Recipe>();

        foreach (var v in recipesFromFile)
        {
            var recipe = RecipesFromFile(v);
            allRecipes.Add(recipe);
        }

        return allRecipes;
    }

    private Recipe RecipesFromFile(string recipesFromFile)
    {
        var texttualIds = recipesFromFile.Split(Separator);
        var ingredients = new List<Ingredient>();

        foreach (var v in texttualIds)
        {
            var id = int.Parse(v);
            var ingredient = _ingredientsRegister.GetByID(id);
            ingredients.Add(ingredient);
        }

        return new Recipe(ingredients);
    }

    public void Write(string filepath, List<Recipe> allRecipes)
    {
        var allStrings = new List<string>();
        foreach (var recipe in allRecipes)
        {
            var allIds = new List<int>();
            foreach (var ingredient in recipe.Ingredients)
            {
                allIds.Add(ingredient.Id);
            }

            allStrings.Add(string.Join(Separator, allIds));
        }

        _stringsRepository.Write(filepath, allStrings);
    }
}
