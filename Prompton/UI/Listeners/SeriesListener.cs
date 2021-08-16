using ConsoleGUI.Input;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;
public class SeriesListener : IInputListener
{
    private readonly SeriesView seriesView;

    public SeriesListener(SeriesView seriesView) {
        this.seriesView = seriesView;
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
