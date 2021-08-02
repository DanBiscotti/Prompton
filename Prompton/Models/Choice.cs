using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public class Choice : Step
    {
        [YamlMember(Alias = "choices")]
        public object[] Choices;
    }
}
