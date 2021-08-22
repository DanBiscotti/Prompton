using ConsoleGUI.Input;
using Prompton.Steps.StepResults;

namespace Prompton.UI.Listeners;

public abstract class StepListener: IInputListener
{
    public abstract void OnInput(InputEvent inputEvent);
    public abstract StepResult GetResult();
}
