using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class TextView : StepView
{
    public Text Step { get; set; }
    private readonly VerticalStackPanel viewStack;
    private readonly Box validationMessage;

    public TextBox TextBox { get; }

    public TextView(Text step)
    {
        this.Step = step;
        validationMessage = BuildTextBox(step.ValidationMessage ?? "", ConsoleColor.Red);

        viewStack = new VerticalStackPanel();
        if (step.Prompt is not null or "")
            viewStack.Add(BuildTextBox(step.Prompt));
        viewStack.Add(new HorizontalSeparator());

        TextBox = new TextBox();
        var border = new Border { Content = new BreakPanel { Content = TextBox } };
        viewStack.Add(border);
        Content = viewStack;
    }

    public bool Validate()
    {
        if (Step.ValidationRegex is null || Step.ValidationMessage is null or "")
        {
            return true;
        }
        if (Step.ValidationRegex.IsMatch(TextBox.Text))
        {
            if (viewStack.Children.Contains(validationMessage))
                viewStack.Remove(validationMessage);
            return true;
        }
        if(!viewStack.Children.Contains(validationMessage))
            viewStack.Add(validationMessage);
        return false;
    }
}
