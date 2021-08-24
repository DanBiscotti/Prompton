using System.Text.RegularExpressions;

namespace Prompton.Steps;

public class Text : Step
{
    public Regex ValidationRegex { get; set; }
    public string ValidationMessage { get; set; }
}
