using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class TextView : StepView
{
    private readonly Text input;
    private readonly VerticalStackPanel viewStack;
    private readonly TextBlock validationMessage;

    public TextBox TextBox { get; }

    public TextView(Text input) : base(input)
    {
        this.input = input;
        validationMessage = new TextBlock { Text = input.ValidationMessage, Color = ConsoleColor.Red };

        viewStack = new VerticalStackPanel();
        if (input.Prompt is not null or "")
            viewStack.Add(BuildPrompt());
        viewStack.Add(new HorizontalSeparator());

        TextBox = new TextBox();
        var border = new Border { Content = new BreakPanel { Content = TextBox } };
        viewStack.Add(border);
        Content = viewStack;
    }

    public bool Validate()
    {
        if (input.ValidationRegex is null || input.ValidationMessage is null or "")
        {
            return true;
        }
        if (input.ValidationRegex.IsMatch(TextBox.Text))
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
