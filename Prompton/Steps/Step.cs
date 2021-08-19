using YamlDotNet.Serialization;

namespace Prompton.Steps;

public abstract class Step
{
    [YamlMember(Alias = "id")]
    public string Id { get; set; }
    [YamlMember(Alias = "prompt")]
    public string Prompt { get; set; }
}
