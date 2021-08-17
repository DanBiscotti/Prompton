using YamlDotNet.Serialization;

namespace Prompton.Steps;

public class ChoiceStep : Step
{
    [YamlMember(Alias = "choices")]
    public Dictionary<string, Step> Choices;
}
