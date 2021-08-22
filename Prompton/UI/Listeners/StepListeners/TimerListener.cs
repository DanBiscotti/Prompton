using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;
public class TimerListener : IInputListener
{
    private readonly TimerView timerView;
    private readonly UIProvider ui;

    public TimerListener(TimerView timerView, UIProvider ui)
    {
        this.timerView = timerView;
        this.ui = ui;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Spacebar:
                {
                    timerView.StopStart();
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.Enter:
                {
                    break;
                }
        }
    }
}
