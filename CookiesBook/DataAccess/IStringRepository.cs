namespace CookiesBook.DataAccess;
public interface IStringsRepository
{
    List<string> Read(string filepath);
    void Write(string filepath, List<string> allStrings);
}
