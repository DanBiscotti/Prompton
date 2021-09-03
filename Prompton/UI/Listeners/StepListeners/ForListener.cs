using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;
public class ForListener : StepListener
{
    private readonly ForView forView;
    private readonly ForResult result;
    private readonly UIProvider ui;

    public ForListener(ForView forView, UIProvider ui)
    {
        this.forView = forView;
        this.ui = ui;
        result = new ForResult
        {
            StepId = forView.Step.Id,
            Result = new List<List<StepResult>>()
        };
    }

    public override StepResult GetResult() => result;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    result.Prompt = forView.Step.Prompt;

                    StepListener listener;
                    var list = new List<StepResult>();

                    var repeats = forView.Step.Repeats;

                    if (forView.Step.PromptForRepeats)
                    {
                        var numberStep = new Number { Prompt = $"Enter a number of times to repeat: {forView.Step.Prompt}" };
                        var numberView = ui.GetView(numberStep);
                        var listeners = ui.GetListeners(numberView);
                        var listenerList = listeners.Select(x => x.Value).ToArray();
                        ui.ViewArea.Content = numberView;
                        while (!numberView.Complete)
                        {
                            Thread.Sleep(10);
                            ConsoleManager.ReadInput(listenerList);
                        }
                        listener = listeners[Constants.StepListenerKey] as StepListener;
                        var stepResult = listener.GetResult() as NumberResult;
                        repeats = (int)stepResult.Result;
                    }

                    for (int i = 0; i < repeats; i++)
                    {
                        if(repeats > 1)
                        {
                            var displayStep = new Display { Prompt = $"{forView.Step.Prompt}: round {i + 1}/{repeats}" };
                            var displayView = ui.GetView(displayStep);
                            var listeners = ui.GetListeners(displayView);
                            var listenerList = listeners.Select(x => x.Value).ToArray();
                            ui.ViewArea.Content = displayView;
                            while (!displayView.Complete)
                            {
                                Thread.Sleep(10);
                                ConsoleManager.ReadInput(listenerList);
                            }
                        }

                        foreach (var step in forView.Step.Steps)
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
                    }

                    if (forView.Step.PromptForRepeats)
                        result.Repeats = repeats;

                    result.Result.Add(list);
                    forView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
