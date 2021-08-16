using ConsoleGUI.Input;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;
public class TimerListener : IInputListener
{
    private readonly TimerView timerView;

    public TimerListener(TimerView timerView)
    {
        this.timerView = timerView;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    break;
                }
        }
    }
}
