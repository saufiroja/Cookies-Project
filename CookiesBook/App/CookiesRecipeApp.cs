using CookiesBook.Recipes;

namespace CookiesBook.App;

public class CookiesRecipesApp
{
    public readonly IRecipesRepository _recipesRepository;
    public readonly IRecipesUserInteraction _recipesUserInteraction;

    public CookiesRecipesApp(IRecipesRepository recipesRepository, IRecipesUserInteraction recipesUserInteraction)
    {
        _recipesRepository = recipesRepository;
        _recipesUserInteraction = recipesUserInteraction;
    }

    public void Run(string filepath)
    {
        // step 1: read recipes from file
        var allRecipes = _recipesRepository.Read(filepath);
        //  step 2: print recipes to console
        _recipesUserInteraction.PrintExistingRecipes(allRecipes);
        // step 3: prompt user for new recipe
        _recipesUserInteraction.PromptToCreateNewRecipe();
        // // step 4: read the ingredients from the user
        var ingredients = _recipesUserInteraction.ReadIngredientsFromUser();

        if (ingredients.Count() > 0)
        {
            var recipes = new Recipe(ingredients);
            allRecipes.Add(recipes);
            _recipesRepository.Write(filepath, allRecipes);

            _recipesUserInteraction.ShowMessage($"Recipe created successfully.");
            _recipesUserInteraction.ShowMessage(recipes.ToString());
        }
        else
        {
            _recipesUserInteraction.ShowMessage($"No ingredients have been selected. Recipe will not be created.");
        }

        _recipesUserInteraction.Exit();
    }
}
