namespace Prompton.Steps.StepResults;

public class WhileResult : StepResult
{
    public string Prompt { get; set; }
    public int Repeats { get; set; }
    public List<StepResult> Result { get; set; }
}
