using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class ChoiceView : StepView
{
    public Choice Step { get; set; }
    private int selected = 0;
    private List<string> displayText;

    private VerticalStackPanel viewStack;
    private Border options;

    public ChoiceView(Choice step)
    {
        this.Step = step;
        displayText = step.Choices.Keys.ToList();
        
        options = new Border();

        viewStack = new VerticalStackPanel();
        if (step.Prompt is not null or "")
            viewStack.Add(BuildTextBox(step.Prompt));
        viewStack.Add(new HorizontalSeparator());
        viewStack.Add(options);
        Refresh();

        Content = viewStack;
    }

    public void Scroll(bool up)
    {
        if (up && selected > 0)
            selected--;
        if (!up && selected < Step.Choices.Count - 1)
            selected++;
        Refresh();
    }

    public string GetSelectedString()
    {
        return displayText[selected];
    }

    public Step GetSelectedStep(string selection)
    {
        return Step.Choices[selection];
    }

    private void Refresh()
    {
        var stack = new VerticalStackPanel();
        for (int i = 0; i < Step.Choices.Count; i++)
        {
            stack.Add(new Background
            {
                Color = i == selected ? ConsoleColor.White : ConsoleColor.Black,
                Content = new TextBlock
                {
                    Color = i == selected ? ConsoleColor.Black : ConsoleColor.White,
                    Text = displayText[i]
                }
            });
        }
        options.Content = stack;
    }
}
