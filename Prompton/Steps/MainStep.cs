using Prompton.Steps.StepResults;
using YamlDotNet.Serialization;

namespace Prompton.Steps;

public class MainStep : SeriesStep
{
    [YamlMember(Alias = "name")]
    public string Name { get; set; }
    [YamlMember(Alias = "definitions-dir")]
    public string DefinitionsDir { get; set; }
    [YamlMember(Alias = "results-dir")]
    public string ResultsDir { get; set; }

    public MainResult GetResult() => new MainResult()
    {
        Name = Name,
        StartDate = DateOnly.FromDateTime(DateTime.Now),
        StartTime = TimeOnly.FromDateTime(DateTime.Now),
        Results = new List<StepResult>()
    };
}
