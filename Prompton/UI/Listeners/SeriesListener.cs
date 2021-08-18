using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;
public class SeriesListener : IInputListener
{
    private readonly SeriesView series;
    private readonly Flag flag;
    private readonly Margin viewArea;
    private readonly Dictionary<string, Step> stepDict;

    public SeriesListener(SeriesView series, Flag flag, Margin viewArea, Dictionary<string, Step> stepDict)
    {
        this.series = series;
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
                    foreach (var step in series.Series.Steps)
                    {
                        var view = step.GetView(stepDict);
                        var listeners = view.GetListeners(flag, viewArea, stepDict);
                        viewArea.Content = view;
                        flag.Next = false;
                        while (!flag.Next && !flag.Quit)
                        {
                            Thread.Sleep(10);
                            ConsoleManager.ReadInput(listeners);
                        }
                    }
                    flag.Next = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
