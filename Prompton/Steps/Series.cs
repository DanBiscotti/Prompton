namespace Prompton.Steps;

public class Series : Step
{
    public List<Step> Steps { get; set; }
    public int Repeats { get; set; } = 1;
}
