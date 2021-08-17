using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;
public class ChoiceView : StepView
{
    private ChoiceStep choice;
    private int selected = 0;
    private List<string> displayText;

    private VerticalStackPanel viewStack;

    public ChoiceView(ChoiceStep choice) : base(choice)
    {
        this.choice = choice;
        displayText = choice.Choices.Keys.ToList();
        Refresh();
    }

    public void Scroll(bool up)
    {
        if (up && selected > 0)
            selected--;
        if (!up && selected < choice.Choices.Count - 1)
            selected++;
        Refresh();
    }

    public Step GetSelected()
    {
        return choice.Choices[displayText[selected]];
    }

    private void Refresh()
    {
        var stack = new VerticalStackPanel();
        for (int i = 0; i < choice.Choices.Count; i++)
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
        Content = stack;
    }
}
