using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class ChoiceListener : IInputListener
{
    private readonly ChoiceView choice;
    private readonly Flag flag;
    private readonly Margin viewArea;
    private readonly Dictionary<string, Step> stepDict;

    public ChoiceListener(ChoiceView choice, Flag flag, Margin viewArea, Dictionary<string, Step> stepDict)
    {
        this.choice = choice;
        this.flag = flag;
        this.viewArea = viewArea;
        this.stepDict = stepDict;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    var step = choice.GetSelected();
                    var view = step.GetView(stepDict);
                    var listeners = view.GetListeners(flag, viewArea, stepDict);
                    while (!flag.Next && !flag.Quit)
                    {
                        Thread.Sleep(10);
                        ConsoleManager.ReadInput(listeners);
                    }
                    flag.Next = true;
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.J
            or ConsoleKey.K:
                {
                    choice.Scroll(inputEvent.Key.Key == ConsoleKey.K);
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
