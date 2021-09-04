using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.Steps.StepResults;

namespace Prompton.UI.Listeners;

public abstract class StepListener: IInputListener
{
    protected readonly UIProvider ui;

    protected StepListener(UIProvider ui)
    {
        this.ui = ui;
    }

    public abstract void OnInput(InputEvent inputEvent);
    public abstract StepResult GetResult();

    public StepResult ProcessStep(Step step)
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
        return listener.GetResult();
    }
}
