using ConsoleGUI.Controls;
using Prompton.Steps;
using System.Text.RegularExpressions;

namespace Prompton.UI.Views;

public class NumberView : StepView
{
    public Number Number { get; }
    private readonly VerticalStackPanel viewStack;
    private readonly Box validationTextBox;
    private static Regex numberRegex = new(@"^[1-9]\d*(\.\d+)?$");

    public TextBox TextBox { get; }

    public NumberView(Number input)
    {
        this.Number = input;
        validationTextBox = BuildTextBox($"Number must be between {Number.Min} and {Number.Max}", ConsoleColor.Red);

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
        if (numberRegex.IsMatch(TextBox.Text))
        {
            if (viewStack.Children.Contains(validationTextBox))
                viewStack.Remove(validationTextBox);
            return true;
        }
        if (!viewStack.Children.Contains(validationTextBox))
            viewStack.Add(validationTextBox);
        return false;
    }
}
