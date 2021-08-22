using ConsoleGUI.Controls;
using Figgle;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class TimerView : StepView
{

    private readonly TimerStep timerStep;
    private readonly string format;
    private Timer timer;
    private VerticalStackPanel viewStack;
    private TextBlock timerArea;
    private TimeSpan timerTime;
    private bool active;
    private bool isCountdown;
    private Box countdownText = new Box { Content = new TextBlock { Text = "Countdown!" } };

    public TimerView(TimerStep timerStep) : base(timerStep)
    {
        this.timerStep = timerStep;
        var countdown = timerStep.Countdown;
        timerTime = countdown > TimeSpan.Zero ? countdown : timerStep.Countup ? TimeSpan.Zero : timerStep.Limit;
        format = timerStep.Limit >= TimeSpan.FromHours(1) ? @"hh\:mm\:ss" : @"mm\:ss";
        isCountdown = timerStep.Countdown > TimeSpan.Zero;

        var displayTime = GetTimeDisplayText(timerTime);
        var width = displayTime.IndexOf('\n') + 1;
        timerArea = new TextBlock
        {
            Text = displayTime,
            Color = isCountdown ? ConsoleColor.Yellow : ConsoleColor.White
        };
        var box = new Box
        {
            Content = new Border
            {
                Content = new Boundary
                {
                    Width = width,
                    Content = new Background
                    {
                        Content = new WrapPanel
                        {
                            Content = new Boundary
                            {
                                MinWidth = width,
                                Content = timerArea
                            }
                        }
                    }
                }
            }
        };

        viewStack = new VerticalStackPanel();
        viewStack.Add(BuildPrompt());
        viewStack.Add(new HorizontalSeparator());
        viewStack.Add(box);
        if (isCountdown)
            viewStack.Add(countdownText);

        Content = viewStack;
    }

    public void Start()
    {
        active = true;
        timer = new Timer(MoveTimer, null, 0, 1000);
    }

    public void Stop()
    {
        active = false;
        timer.Dispose();
    }

    public void StopStart()
    {
        if (active)
            Stop();
        else
            Start();
    }

    private void MoveTimer(Object _)
    {
        if(isCountdown)
        {
            if (timerTime == TimeSpan.FromSeconds(1))
            {
                if (!timerStep.Countup)
                    timerTime = timerStep.Limit;
                else
                    timerTime += TimeSpan.FromSeconds(1);
                timerArea.Color = ConsoleColor.White;
                isCountdown = false;
                viewStack.Remove(countdownText);
            }
            else
            {
                timerTime -= TimeSpan.FromSeconds(1);
            }
        }
        else if (timerTime == TimeSpan.Zero && !timerStep.Countup)
        {
            Stop();
        }
        else if (timerTime == timerStep.Limit && timerStep.Countup)
        {
            Stop();
        }
        else
        {
            if (timerStep.Countup)
                timerTime += TimeSpan.FromSeconds(1);
            else
                timerTime -= TimeSpan.FromSeconds(1);
        }
        timerArea.Text = GetTimeDisplayText(timerTime);
    }

    private string GetTimeDisplayText(TimeSpan time) => FiggleFonts.Blocks.Render(time.ToString(format));
}
