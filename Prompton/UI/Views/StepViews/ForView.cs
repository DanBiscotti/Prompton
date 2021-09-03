using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class ForView : StepView
{
    public For Step { get; set; }

    public ForView(For step)
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
