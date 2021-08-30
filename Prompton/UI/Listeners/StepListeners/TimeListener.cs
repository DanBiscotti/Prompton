using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;
public class TimeListener : StepListener
{
    private readonly TimeView timeView;
    private readonly TimerResult result;

    public TimeListener(TimeView timeView)
    {
        this.timeView = timeView;
        result = new TimerResult
        {
            StepId = timeView.Step.Id,
            Prompt = timeView.Step.Prompt
        };
    }

    public override StepResult GetResult() => result;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Spacebar:
                {
                    timeView.StopStart();
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.Enter:
                {
                    if(!timeView.IsCountdown)
                    {
                        result.Result = timeView.Step.Countup
                            ? timeView.TimerTime
                            : timeView.Step.Limit - timeView.TimerTime;
                        timeView.Complete = true;
                    }
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.J
            or ConsoleKey.K
            or ConsoleKey.DownArrow
            or ConsoleKey.UpArrow:
                {
                    timeView.MoveTimer(inputEvent.Key.Key is ConsoleKey.K or ConsoleKey.UpArrow);
                    inputEvent.Handled = true;
                    break;
                }
        }
    }
}