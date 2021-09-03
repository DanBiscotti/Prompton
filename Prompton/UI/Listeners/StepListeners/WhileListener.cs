using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;
public class WhileListener : StepListener
{
    private readonly WhileView whileView;
    private readonly WhileResult result;
    private readonly UIProvider ui;

    public WhileListener(WhileView whileView, UIProvider ui)
    {
        this.whileView = whileView;
        this.ui = ui;
        result = new WhileResult
        {
            StepId = whileView.Step.Id,
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
                    result.Prompt = whileView.Step.Prompt;

                    StepListener listener;
                    var resultList = new List<StepResult>();

                    var breakLoop = false;

                    var repeats = 0;
                    while (!breakLoop)
                    {
                        repeats++;
                        foreach (var step in whileView.Step.Steps)
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
                            resultList.Add(listener.GetResult());
                        }
                        var choiceStep = new Choice
                        {
                            Prompt = $"Would you like to repeat again: {whileView.Step.Prompt} (current count: {repeats})",
                            Choices = new() { { "Yes", null }, { "No", null } }
                        };
                        var choiceView = ui.GetView(choiceStep);
                        var choiceListeners = ui.GetListeners(choiceView);
                        var choiceListenerList = choiceListeners.Select(x => x.Value).ToArray();
                        ui.ViewArea.Content = choiceView;
                        while (!choiceView.Complete)
                        {
                            Thread.Sleep(10);
                            ConsoleManager.ReadInput(choiceListenerList);
                        }
                        listener = choiceListeners[Constants.StepListenerKey] as StepListener;
                        var stepResult = listener.GetResult() as ChoiceResult;
                        breakLoop = stepResult.Choice == "No";
                    }
                    result.Repeats = repeats;

                    result.Result.Add(resultList);
                    whileView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
