using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public class Series : Step
    {
        [YamlMember(Alias = "steps")]
        public Step[] Steps { get; set; }
        [YamlMember(Alias = "repeats")]
        public int  Repeats { get; set; } = 1;
    }
}
