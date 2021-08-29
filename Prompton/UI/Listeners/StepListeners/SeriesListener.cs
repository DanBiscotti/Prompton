using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;
public class SeriesListener : StepListener
{
    private readonly SeriesView seriesView;
    private readonly SeriesResult seriesResult;
    private readonly UIProvider ui;

    public SeriesListener(SeriesView seriesView, UIProvider ui)
    {
        this.seriesView = seriesView;
        this.ui = ui;
        seriesResult = new SeriesResult
        {
            StepId = seriesView.Step.Id,
            Result = new List<List<StepResult>>()
        };
    }

    public override StepResult GetResult() => seriesResult;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    seriesResult.Prompt = seriesView.Step.Prompt;

                    StepListener listener;
                    for (int i = 0; i < seriesView.Step.Repeats; i++)
                    {
                        var list = new List<StepResult>();
                        foreach (var step in seriesView.Step.Steps)
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
                        seriesResult.Result.Add(list);
                    }
                    seriesView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
