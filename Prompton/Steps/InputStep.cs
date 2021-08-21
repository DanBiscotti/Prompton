using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

namespace Prompton.Steps;

public class InputStep : Step
{
    [YamlMember(Alias = "validationRegex")]
    public Regex ValidationRegex { get; set; }
    [YamlMember(Alias = "validationMessage")]
    public string ValidationMessage { get; set; }
}
