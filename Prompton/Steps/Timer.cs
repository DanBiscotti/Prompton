namespace Prompton.Steps;

public class Timer : Step
{
    public bool Countup { get; set; }
    public TimeSpan Countdown { get; set; }
    public TimeSpan Limit { get; set; }
}
