namespace CookiesBook.Recipes.Ingredients;

public interface IIngredientsRegister
{
    IEnumerable<Ingredient> All { get; }
    Ingredient GetByID(int id);
}
