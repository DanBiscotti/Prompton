namespace Prompton.Steps.StepResults;

public class MainResult : StepResult
{
    public string Name {  get; set; }
    public DateOnly StartDate {  get; set; }
    public TimeOnly StartTime {  get; set; }
    public TimeSpan Duration { get; set; }
    public List<StepResult> Results {  get; set; }
}
