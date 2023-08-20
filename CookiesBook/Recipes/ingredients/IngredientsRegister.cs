namespace CookiesBook.Recipes.Ingredients;

public class IngredientsRegister : IIngredientsRegister
{
    public IEnumerable<Ingredient> All { get; } = new List<Ingredient>{
        new WheatFlour(),
        new SpeltFlour(),
        new Butter(),
        new Chocolate(),
        new Sugar(),
        new Cardamon(),
        new Cinnamon(),
        new CocoaPowder (),
    };

    public Ingredient GetByID(int id)
    {
        foreach (var ingredient in All)
        {
            if (ingredient.Id == id)
            {
                return ingredient;
            }
        }

        return null;
    }
}