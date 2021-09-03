namespace Prompton.Steps.StepResults;

public class ForResult : StepResult
{
    public string Prompt { get; set; }
    public int Repeats { get; set; }
    public List<List<StepResult>> Result { get; set; }
}
