using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public class Series : Step
    {
        [YamlMember(Alias = "steps")]
        public Step[] Steps { get; set; }
    }
}
