using ConsoleGUI.Controls;
using Figgle;
using SharpAudio;
using SharpAudio.Codec;
using Time = Prompton.Steps.Time;

namespace Prompton.UI.Views;

public class TimeView : StepView
{
    public TimeSpan TimerTime { get; set; }
    public Time Step { get; }
    public bool IsCountdown { get; set; }
    public bool IsStarted { get; set; } = false;
    private readonly string format;
    private Timer timer;
    private VerticalStackPanel viewStack;
    private TextBlock timerArea;
    private bool active;
    private Box countdownText = BuildTextBox("Countdown!", ConsoleColor.Yellow);
    private AudioEngine audioEngine;

    public TimeView(Time step, AudioEngine audioEngine)
    {
        this.audioEngine = audioEngine;
        this.Step = step;
        var countdown = step.Countdown;
        TimerTime = countdown > TimeSpan.Zero ? countdown : step.Countup ? TimeSpan.Zero : step.Limit;
        format = step.Limit >= TimeSpan.FromHours(1) ? @"hh\:mm\:ss" : @"mm\:ss";
        IsCountdown = step.Countdown > TimeSpan.Zero;

        var displayTime = GetTimeDisplayText(TimerTime);
        var width = displayTime.IndexOf('\n') + 1;
        timerArea = new TextBlock
        {
            Text = displayTime,
            Color = IsCountdown ? ConsoleColor.Yellow : ConsoleColor.White
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
        viewStack.Add(BuildTextBox(step.Prompt));
        viewStack.Add(new HorizontalSeparator());
        viewStack.Add(box);
        if (IsCountdown)
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
        if (up)
            TimerTime += TimeSpan.FromSeconds(1);
        else
            TimerTime -= TimeSpan.FromSeconds(1);

        timerArea.Text = GetTimeDisplayText(TimerTime);
    }

    private void Start()
    {
        active = true;
        IsStarted = true;
        timer = new Timer(this.MoveTimer, null, 0, 1000);
    }

    public void Stop()
    {
        active = false;
        timer.Dispose();
    }

    private void MoveTimer(Object _)
    {
        if (IsCountdown)
        {
            if (TimerTime == TimeSpan.FromSeconds(1))
            {
                PlaySound();
                if (!Step.Countup)
                    TimerTime = Step.Limit;
                else
                    TimerTime = TimeSpan.Zero;
                timerArea.Color = ConsoleColor.White;
                IsCountdown = false;
                viewStack.Remove(countdownText);
            }
            else
            {
                TimerTime -= TimeSpan.FromSeconds(1);
            }
        }
        else if (TimerTime == TimeSpan.Zero && !Step.Countup)
        {
            PlaySound();
            Stop();
        }
        else if (TimerTime == Step.Limit && Step.Countup)
        {
            PlaySound();
            Stop();
        }
        else
        {
            if (Step.Countup)
                TimerTime += TimeSpan.FromSeconds(1);
            else
                TimerTime -= TimeSpan.FromSeconds(1);
        }
        timerArea.Text = GetTimeDisplayText(TimerTime);
    }

    private void PlaySound()
    {
        var soundStream = new SoundStream(Resources.BellSound, audioEngine);
        soundStream.Volume = 1f;
        soundStream.Play();
    }

    private string GetTimeDisplayText(TimeSpan time) => FiggleFonts.Blocks.Render(time.ToString(format)); // Also ThreeByFive works and takes up less space
}
