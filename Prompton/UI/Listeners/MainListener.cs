using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class MainListener : IInputListener
{
    private readonly MainView mainView;
    private readonly UIProvider ui;

    public MainListener(MainView mainView, UIProvider ui)
    {
        this.mainView = mainView;
        this.ui = ui;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    foreach (var step in mainView.Main.Steps)
                    {
                        var view = ui.GetView(step);
                        ui.ViewArea.Content = view;
                        var listeners = ui.GetListeners(view);
                        ui.Flag.Next = false;
                        while (!ui.Flag.Next && !ui.Flag.Quit)
                        {
                            Thread.Sleep(10);
                            ConsoleManager.ReadInput(listeners);
                        }
                    }
                    ui.Flag.Next = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
