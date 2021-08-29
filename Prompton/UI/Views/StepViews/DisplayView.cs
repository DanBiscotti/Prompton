using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class DisplayView : StepView
{
    public Display Step { get; set; }

    public DisplayView(Display step)
    {
        Step = step;
        Content = new VerticalStackPanel()
        {
            Children = new IControl[]
            {
                BuildTextBox(step.Prompt),
                BuildTextBox("Press enter to continue"),
            }
        };
    }
}
