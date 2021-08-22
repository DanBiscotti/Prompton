using Prompton.Steps;
using Prompton.Steps.StepResults;

namespace Prompton.Yaml;

public interface  IYamlSerializer
{
    string Serialize(MainResult main);
}

public class YamlSerializer : IYamlSerializer
{
    public string Serialize(MainResult main)
    {
        throw new NotImplementedException();
    }
}
