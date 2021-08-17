using ConsoleGUI.Input;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class InputListener : IInputListener
{
    private readonly InputView view;
    private readonly Flag flag;

    public InputListener(InputView view, Flag flag)
    {
        this.view = view;
        this.flag = flag;
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
