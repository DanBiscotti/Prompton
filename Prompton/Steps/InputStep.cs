using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

namespace Prompton.Steps;

public class InputStep : Step
{
    [YamlMember(Alias = "textarea")]
    public bool TextArea { get; set; }
    [YamlMember(Alias = "validate")]
    public bool Validate {  get; set; }
    [YamlMember(Alias = "validationRegex")]
    public Regex ValidationRegex { get; set; }
    [YamlMember(Alias = "validationMessage")]
    public string ValidationMessage { get; set; }
}
