namespace CookiesBook.Recipes.Ingredients;

public abstract class Flour : Ingredient
{
    public override string PreparationInstructions => $"Sieve. {base.PreparationInstructions}";
}


public class SpeltFlour : Flour
{
    public override int Id => 2;
    public override string Name => "Spelt Flour";
}


public class WheatFlour : Flour
{
    public override int Id => 1;
    public override string Name => "Wheat Flour";
}
