using CookiesBook.Recipes;
using CookiesBook.Recipes.Ingredients;

namespace CookiesBook.App;

public class RecipesUserInteraction : IRecipesUserInteraction
{
    private readonly IIngredientsRegister _ingredientsRegister;

    public RecipesUserInteraction(IIngredientsRegister ingredientsRegister)
    {
        _ingredientsRegister = ingredientsRegister;
    }
    public void Exit()
    {
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }

    public void PrintExistingRecipes(IEnumerable<Recipe> allRecipes)
    {
        if (allRecipes.Count() > 0)
        {
            Console.WriteLine("Existing recipes:" + Environment.NewLine);
            var count = 1;
            foreach (var recipe in allRecipes)
            {
                Console.WriteLine($"*****{count}*****");
                Console.WriteLine(recipe);
                Console.WriteLine();
                count++;
            }
        }
    }

    public void PromptToCreateNewRecipe()
    {
        Console.WriteLine("Create a new cookie receipe! Available ingredients are:");
        foreach (var ingredient in _ingredientsRegister.All)
        {
            Console.WriteLine($"{ingredient.Id}. {ingredient.Name}");
        }
    }
    public void ShowMessage(string message)
    {
        Console.WriteLine(message);
    }

    public IEnumerable<Ingredient> ReadIngredientsFromUser()
    {
        bool shallStop = false;
        var ingredients = new List<Ingredient>();

        while (!shallStop)
        {
            Console.WriteLine("Add an ingredient by its ID, or type anything else if finished.");
            var input = Console.ReadLine();
            if (int.TryParse(input, out int id))
            {
                var selectedIngredient = _ingredientsRegister.GetByID(id);
                if (selectedIngredient != null)
                {
                    ingredients.Add(selectedIngredient);
                }
            }
            else
            {
                shallStop = true;
            }
        }

        return ingredients;
    }
}
