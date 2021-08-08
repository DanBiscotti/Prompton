using System;
using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public class Timer : Step
    {
        [YamlMember(Alias = "countdown")]
        public bool Countdown { get; set; }
        [YamlMember(Alias = "limit")]
        public TimeSpan Limit { get; set; }
    }
}
