using ConsoleGUI.Input;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;

public class ChoiceListener : IInputListener
{
    private readonly ChoiceView view;
    private readonly Flag flag;

    public ChoiceListener(ChoiceView view, Flag flag)
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
