using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public class Series : Step
    {
        [YamlMember(Alias = "steps")]
        public List<Step> Steps { get; set; }
        [YamlMember(Alias = "repeats")]
        public int  Repeats { get; set; } = 1;
    }
}
