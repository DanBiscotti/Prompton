using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class TextView : StepView
{
    public Text TextStep { get; set; }
    private readonly VerticalStackPanel viewStack;
    private readonly Box validationMessage;

    public TextBox TextBox { get; }

    public TextView(Text input)
    {
        this.TextStep = input;
        validationMessage = BuildTextBox(input.ValidationMessage ?? "", ConsoleColor.Red);

        viewStack = new VerticalStackPanel();
        if (input.Prompt is not null or "")
            viewStack.Add(BuildTextBox(input.Prompt));
        viewStack.Add(new HorizontalSeparator());

        TextBox = new TextBox();
        var border = new Border { Content = new BreakPanel { Content = TextBox } };
        viewStack.Add(border);
        Content = viewStack;
    }

    public bool Validate()
    {
        if (TextStep.ValidationRegex is null || TextStep.ValidationMessage is null or "")
        {
            return true;
        }
        if (TextStep.ValidationRegex.IsMatch(TextBox.Text))
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
