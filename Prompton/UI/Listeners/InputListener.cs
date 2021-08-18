using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class InputListener : IInputListener
{
    private readonly InputView inputView;
    private readonly Flag flag;
    private readonly Margin viewArea;
    private readonly Dictionary<string, Step> stepDict;

    public InputListener(InputView inputView, Flag flag, Margin viewArea, Dictionary<string, Step> stepDict)
    {
        this.inputView = inputView;
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
                inputEvent.Handled = true;
                return;
            }
            case ConsoleKey.J
            or ConsoleKey.K:
            {
                inputEvent.Handled = true;
                return;
            }
        }
    }
}
