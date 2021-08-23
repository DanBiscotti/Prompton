namespace Prompton.Steps.StepResults;

public class ChoiceResult : StepResult
{
    public string Prompt { get; set; }
    public string Choice { get; set; }
    public StepResult Result { get; set; }
}
