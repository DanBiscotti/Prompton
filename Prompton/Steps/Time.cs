using System;

namespace Prompton.Steps;

public class Time : Step
{
    public bool Countup { get; set; }
    public TimeSpan Countdown { get; set; }
    public TimeSpan Limit { get; set; }
}
