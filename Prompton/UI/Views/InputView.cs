using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class InputView : StepView
{

    private InputStep input;

    private VerticalStackPanel viewStack;
    public TextBox TextBox { get; }
        
    public InputView(InputStep input) : base(input)
    {
        this.input = input;

        viewStack = new VerticalStackPanel();
        if (input.Prompt is not null or "")
            viewStack.Add(BuildPrompt());
        viewStack.Add(new HorizontalSeparator());

        TextBox = new TextBox();
        var border = new Border { };
        if (input.TextArea)
            border.Content = new BreakPanel { Content = TextBox };
        else
            border.Content = TextBox;
        viewStack.Add(border);
        Content = viewStack;
    }
}
