using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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
        mainResult = MainResult.Create(mainView.Step.Id, mainView.Step.Name, mainView.Step.Tags);
    }

    public override StepResult GetResult()
    {
        mainResult.Duration = DateTime.UtcNow - mainResult.StartDateUtc.ToDateTime(mainResult.StartTimeUtc, DateTimeKind.Utc);
        return mainResult;
    }

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    StepListener listener;
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
                    mainView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
