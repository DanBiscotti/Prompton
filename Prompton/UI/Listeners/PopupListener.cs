using ConsoleGUI.Input;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class PopupListener : IInputListener
{
    private readonly Popup popup;

    public PopupListener(Popup popup)
    {
        this.popup = popup;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    popup.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.H
            or ConsoleKey.L:
                {
                    popup.Scroll(inputEvent.Key.Key == ConsoleKey.H);
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
