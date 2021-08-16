using ConsoleGUI.Input;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;

public class MainListener : IInputListener
{
    private readonly MainView view;

    public MainListener(MainView view)
    {
        this.view = view;
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
