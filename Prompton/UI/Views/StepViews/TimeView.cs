using ConsoleGUI.Controls;
using Figgle;
using Prompton.Steps;
using Time = Prompton.Steps.Time;

namespace Prompton.UI.Views;

public class TimeView : StepView
{
    public TimeSpan TimerTime { get; set; }
    public Time TimeStep { get; }
    private readonly string format;
    private Timer timer;
    private VerticalStackPanel viewStack;
    private TextBlock timerArea;
    private bool active;
    private bool isCountdown;
    private Box countdownText = BuildTextBox("Countdown!", ConsoleColor.Yellow);

    public TimeView(Time timeStep)
    {
        this.TimeStep = timeStep;
        var countdown = timeStep.Countdown;
        TimerTime = countdown > TimeSpan.Zero ? countdown : timeStep.Countup ? TimeSpan.Zero : timeStep.Limit;
        format = timeStep.Limit >= TimeSpan.FromHours(1) ? @"hh\:mm\:ss" : @"mm\:ss";
        isCountdown = timeStep.Countdown > TimeSpan.Zero;

        var displayTime = GetTimeDisplayText(TimerTime);
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
        viewStack.Add(BuildTextBox(timeStep.Prompt));
        viewStack.Add(new HorizontalSeparator());
        viewStack.Add(box);
        if (isCountdown)
            viewStack.Add(countdownText);

        Content = viewStack;
    }

    public void StopStart()
    {
        if (active)
            Stop();
        else
            Start();
    }

    public void MoveTimer(bool up)
    {
        if(up)
            TimerTime += TimeSpan.FromSeconds(1);
        else
            TimerTime -= TimeSpan.FromSeconds(1);

        timerArea.Text = GetTimeDisplayText(TimerTime);
    }

    private void Start()
    {
        active = true;
        timer = new Timer(this.MoveTimer, null, 0, 1000);
    }

    private void Stop()
    {
        active = false;
        timer.Dispose();
    }

    private void MoveTimer(Object _)
    {
        if (isCountdown)
        {
            if (TimerTime == TimeSpan.FromSeconds(1))
            {
                if (!TimeStep.Countup)
                    TimerTime = TimeStep.Limit;
                else
                    TimerTime = TimeSpan.Zero;
                timerArea.Color = ConsoleColor.White;
                isCountdown = false;
                viewStack.Remove(countdownText);
            }
            else
            {
                TimerTime -= TimeSpan.FromSeconds(1);
            }
        }
        else if (TimerTime == TimeSpan.Zero && !TimeStep.Countup)
        {
            Stop();
        }
        else if (TimerTime == TimeStep.Limit && TimeStep.Countup)
        {
            Stop();
        }
        else
        {
            if (TimeStep.Countup)
                TimerTime += TimeSpan.FromSeconds(1);
            else
                TimerTime -= TimeSpan.FromSeconds(1);
        }
        timerArea.Text = GetTimeDisplayText(TimerTime);
    }

    private string GetTimeDisplayText(TimeSpan time) => FiggleFonts.Blocks.Render(time.ToString(format)); // Also ThreeByFive works and takes up less space
}
