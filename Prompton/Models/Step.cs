using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public abstract class Step
    {
        [YamlMember(Alias = "id")]
        public string Id { get; set; }
        [YamlMember(Alias = "name")]
        public string Name { get; set; }
    }
}
