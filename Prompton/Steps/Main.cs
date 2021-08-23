using Prompton.Steps.StepResults;

namespace Prompton.Steps;

public class Main : Series
{
    public string Name { get; set; }
    public string DefinitionsDir { get; set; }
    public string ResultsDir { get; set; }
}
