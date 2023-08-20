namespace CookiesBook.DataAccess;

public class StringsTextualRepository : StringsRepository
{
    private static readonly string Separator = Environment.NewLine;

    protected override string StringsToText(List<string> allStrings)
    {
        return string.Join(Separator, allStrings);
    }

    protected override List<string> TextToStrings(string fileContent)
    {
        return fileContent.Split(Separator).ToList();
    }
}
