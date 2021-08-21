using ConsoleGUI.Input;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class InputListener : IInputListener
{
    private readonly InputView inputView;
    private readonly UIProvider ui;

    public InputListener(InputView inputView, UIProvider ui)
    {
        this.inputView = inputView;
        this.ui = ui;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    if(inputView.Validate())
                    {
                        inputView.Complete = true;
                    }
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
