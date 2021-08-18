using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class MainListener : IInputListener
{
    private readonly MainView main;
    private readonly Flag flag;
    private readonly Margin viewArea;
    private readonly Dictionary<string, Step> stepDict;

    public MainListener(MainView main, Flag flag, Margin viewArea, Dictionary<string, Step> stepDict)
    {
        this.main = main;
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
                    foreach (var step in main.Main.Steps)
                    {
                        var view = step.GetView(stepDict);
                        viewArea.Content = view;
                        var listeners = view.GetListeners(flag, viewArea, stepDict);
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
