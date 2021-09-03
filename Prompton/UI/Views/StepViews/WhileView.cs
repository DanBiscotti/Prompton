using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class WhileView : StepView
{
    public While Step { get; set; }

    public WhileView(While step)
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
