namespace CookiesBook.DataAccess;

public abstract class StringsRepository : IStringsRepository
{
    public List<string> Read(string filepath)
    {
        if (!File.Exists(filepath))
        {
            return new List<string>();
        }
        var fileContent = File.ReadAllText(filepath);
        return TextToStrings(fileContent);
    }

    protected abstract List<string> TextToStrings(string fileContent);

    public void Write(string filepath, List<string> allStrings)
    {
        File.WriteAllText(filepath, StringsToText(allStrings));
    }

    protected abstract string StringsToText(List<string> allStrings);
}
