using System;
using YamlDotNet.Serialization;

namespace Prompton.Steps;

public class TimerStep : Step
{
    [YamlMember(Alias = "countdown")]
    public bool Countdown { get; set; }
    [YamlMember(Alias = "limit")]
    public TimeSpan Limit { get; set; }
}
