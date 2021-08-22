using ConsoleGUI.Input;
using Prompton.Steps.StepResults;

namespace Prompton.UI.Listeners;
public class QuitListener : StepListener
{
    public QuitListener() { }

    public override StepResult GetResult()
    {
        throw new NotImplementedException();
    }

    public override void OnInput(InputEvent inputEvent) { }
}
