using ConsoleGUI.Input;
using Prompton.Steps.StepResults;

namespace Prompton.UI.Listeners;
public class QuitListener : StepListener
{
    public QuitListener(UIProvider ui) : base(ui) { }

    public override StepResult GetResult()
    {
        throw new NotImplementedException(); // TODO: E implement
    }

    public override void OnInput(InputEvent inputEvent) { } // TODO: D implement
}
