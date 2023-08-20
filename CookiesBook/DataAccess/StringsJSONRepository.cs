namespace CookiesBook.DataAccess;

using System.Text.Json;

public class StringsJSONRepository : StringsRepository
{
    protected override string StringsToText(List<string> allStrings)
    {
        return JsonSerializer.Serialize(allStrings);
    }

    protected override List<string> TextToStrings(string fileContent)
    {
        return JsonSerializer.Deserialize<List<string>>(fileContent);
    }
}