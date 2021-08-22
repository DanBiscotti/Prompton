using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class MainListener : StepListener
{
    private readonly MainView mainView;
    private readonly MainResult mainResult;
    private readonly UIProvider ui;

    public MainListener(MainView mainView, UIProvider ui)
    {
        this.mainView = mainView;
        this.ui = ui;
        mainResult = mainView.Main.GetResult();
    }

    public override StepResult GetResult()
    {
        throw new NotImplementedException();
    }

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    for(int i = 0; i < mainView.Main.Repeats; i++)
                    {
                        foreach (var step in mainView.Main.Steps)
                        {
                            var view = ui.GetView(step);
                            ui.ViewArea.Content = view;
                            var listeners = ui.GetListeners(view);
                            var listenerList = listeners.Select(x => x.Value).ToArray();
                            while (!view.Complete)
                            {
                                Thread.Sleep(10);
                                ConsoleManager.ReadInput(listenerList);
                            }

                        }
                    }
                    mainView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
