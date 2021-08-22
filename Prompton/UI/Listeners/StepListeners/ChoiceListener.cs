using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class ChoiceListener : StepListener
{
    private readonly ChoiceView choiceView;
    private readonly UIProvider ui;

    public ChoiceListener(ChoiceView choiceView, UIProvider ui)
    {
        this.choiceView = choiceView;
        this.ui = ui;
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
                    var step = choiceView.GetSelected();
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
