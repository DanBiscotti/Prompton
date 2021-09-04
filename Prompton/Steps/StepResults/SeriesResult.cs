namespace Prompton.Steps.StepResults;

public class SeriesResult : StepResult
{
    public string Prompt { get; set; }
    public List<StepResult> Result { get; set; }
}
