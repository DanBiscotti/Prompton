using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class InputListener : IInputListener
{
    private readonly InputView inputView;
    private readonly UIProvider provider;

    public InputListener(InputView inputView, UIProvider provider)
    {
        this.inputView = inputView;
        this.provider = provider;
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
