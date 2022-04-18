using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;
using System;
using System.Linq;
using System.Threading;

namespace Prompton.UI.Listeners;

public class ChoiceListener : StepListener
{
    private readonly ChoiceView choiceView;
    private readonly UIProvider ui;
    private readonly ChoiceResult result;

    public ChoiceListener(ChoiceView choiceView, UIProvider ui)
    {
        this.choiceView = choiceView;
        this.ui = ui;
        result = new ChoiceResult { StepId = choiceView.Step.Id, Prompt = choiceView.Step.Prompt };
    }

    public override StepResult GetResult() => result;

    public override void OnInput(InputEvent inputEvent)
    
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    result.Choice = choiceView.GetSelectedString();
                    var step = choiceView.GetSelectedStep(result.Choice);
                    if (step is not null)
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
                        var listener = listeners[Constants.StepListenerKey] as StepListener;
                        result.Result = listener.GetResult();
                    }
                    choiceView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.J
            or ConsoleKey.K
            or ConsoleKey.DownArrow
            or ConsoleKey.UpArrow:
                {
                    choiceView.Scroll(inputEvent.Key.Key is ConsoleKey.K or ConsoleKey.UpArrow);
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
