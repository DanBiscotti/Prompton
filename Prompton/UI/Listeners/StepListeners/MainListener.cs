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
        mainResult = MainResult.Create(mainView.Step.Id, mainView.Step.Name);
    }

    public override StepResult GetResult()
    {
        mainResult.Duration = DateTime.Now - mainResult.StartDate.ToDateTime(mainResult.StartTime);
        return mainResult;
    }

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    StepListener listener;
                    for (int i = 0; i < mainView.Step.Repeats; i++)
                    {
                        var list = new List<StepResult>();
                        foreach (var step in mainView.Step.Steps)
                        {
                            var view = ui.GetView(step);
                            var listeners = ui.GetListeners(view);
                            var listenerList = listeners.Select(x => x.Value).ToArray();
                            ui.ViewArea.Content = view;
                            while (!view.Complete)
                            {
                                Thread.Sleep(10);
                                ConsoleManager.ReadInput(listenerList);
                            }
                            listener = listeners[Constants.StepListenerKey] as StepListener;
                            list.Add(listener.GetResult());
                        }
                        mainResult.Result.Add(list);
                    }
                    mainView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
