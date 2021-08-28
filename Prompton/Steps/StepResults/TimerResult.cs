namespace Prompton.Steps.StepResults;

public class TimerResult : StepResult
{
    public string Prompt { get; set; }
    public TimeSpan Result { get; set; }
}
