namespace Prompton;

public class FileReader
{
    public List<string> GetYamlStrings(List<string> filepaths)
    {
        var result = new List<string>();
        foreach(var filepath in filepaths)
        {
            result.Add(File.ReadAllText(filepath));
        }
        return result;
    }
}
