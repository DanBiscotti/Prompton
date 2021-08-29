namespace Prompton.Steps.StepResults;

public class MainResult : StepResult
{
    public string Name {  get; set; }
    public Guid ResultGuid {  get; set; }
    public DateOnly StartDate {  get; set; }
    public TimeOnly StartTime {  get; set; }
    public TimeSpan Duration { get; set; }
    public List<List<StepResult>> Result {  get; set; }

    public static MainResult Create(string id, string name) => new MainResult()
    {
        StepId = id,
        Name = name,
        ResultGuid = Guid.NewGuid(),
        StartDate = DateOnly.FromDateTime(DateTime.Now),
        StartTime = TimeOnly.FromDateTime(DateTime.Now),
        Result = new List<List<StepResult>>()
    };
}
