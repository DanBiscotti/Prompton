namespace Prompton.Steps;

public class Main : Step
{
    public string Name { get; set; }
    public List<string> Tags { get; set; }
    public string DefinitionsDir { get; set; }
    public string ResultsDir { get; set; }
    public Step Step { get; set; }
}
