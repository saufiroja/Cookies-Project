using CookiesBook.Recipes;
using CookiesBook.Recipes.Ingredients;
using CookiesBook.DataAccess;
using CookiesBook.FileAccess;
using CookiesBook.App;

namespace CookiesBook;

class Program
{
    public static void Main(string[] args)
    {
        const FileFormat Format = FileFormat.Json;

        IStringsRepository stringsRepository = Format == FileFormat.Json ? new StringsJSONRepository() : new StringsTextualRepository();
        const string FileName = "recipes";
        var fileMetaData = new FileMetaData(FileName, Format);

        var ingredientsRegister = new IngredientsRegister();

        var cookiesRecipesApp = new CookiesRecipesApp(
            new RecipesRepository(
                stringsRepository,
                ingredientsRegister
            ),
            new RecipesUserInteraction(
                ingredientsRegister
            )
        );
        cookiesRecipesApp.Run(fileMetaData.ToPath());

    }
}

