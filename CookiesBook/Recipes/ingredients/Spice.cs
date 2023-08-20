namespace CookiesBook.Recipes.Ingredients;

public abstract class Spice : Ingredient
{
    public override string PreparationInstructions => $"Take half a teaspoon. {base.PreparationInstructions}";
}

public class Cinnamon : Spice
{
    public override int Id => 7;
    public override string Name => "Cinnamon";
}

public class Cardamon : Spice
{
    public override int Id => 6;
    public override string Name => "Cardamon";
}
