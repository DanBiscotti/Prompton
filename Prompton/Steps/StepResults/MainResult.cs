namespace Prompton.Steps.StepResults;

public class MainResult : StepResult
{
    public string Name {  get; set; }
    public Guid ResultGuid {  get; set; }
    public List<string> Tags { get; set; }
    public DateOnly StartDateUtc {  get; set; }
    public TimeOnly StartTimeUtc {  get; set; }
    public TimeSpan Duration { get; set; }
    public StepResult Result {  get; set; }

    public static MainResult Create(string id, string name, List<string> tags) => new MainResult()
    {
        StepId = id,
        Name = name,
        ResultGuid = Guid.NewGuid(),
        Tags = tags,
        StartDateUtc = DateOnly.FromDateTime(DateTime.UtcNow),
        StartTimeUtc = TimeOnly.FromDateTime(DateTime.UtcNow)
    };
}
