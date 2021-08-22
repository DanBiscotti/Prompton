using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;
public class TimerListener : StepListener
{
    private readonly TimerView timerView;

    public TimerListener(TimerView timerView)
    {
        this.timerView = timerView;
    }

    public override StepResult GetResult()
    {
        throw new NotImplementedException();
    }

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Spacebar:
                {
                    timerView.StopStart();
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.Enter:
                {
                    timerView.StoreResult();
                    timerView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}