using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class MainListener : IInputListener
{
    public readonly MainView view;
    private readonly Flag flag;
    private readonly Margin viewArea;

    public MainListener(MainView view, Flag flag, Margin viewArea)
    {
        this.view = view;
        this.flag = flag;
        this.viewArea = viewArea;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    foreach (var step in view.Main.Steps)
                    {
                        viewArea.Content = step.GetView();
                        var listeners = view.GetListeners(flag, viewArea);
                        flag.Next = false;
                        while(!flag.Next && !flag.Quit)
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
