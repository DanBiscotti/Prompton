using YamlDotNet.Serialization;

namespace Prompton.Steps;

public class TimerStep : Step
{
    [YamlMember(Alias = "countup")]
    public bool Countup { get; set; }
    [YamlMember(Alias = "countdown")]
    public TimeSpan Countdown { get; set; }
    [YamlMember(Alias = "limit")]
    public TimeSpan Limit { get; set; }
}
