namespace Prompton.Steps;

public class For : Step
{
    public Step Step { get; set; }
    public int Repeats { get; set; }
    public bool PromptForRepeats { get; set; }
}