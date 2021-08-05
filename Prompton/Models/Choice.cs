using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public class Choice : Step
    {
        [YamlMember(Alias = "choices")]
        public object[] Choices;

        public string[] GetDisplayNames()
        {
            string[] result = new string[Choices.Length];
            for (int i = 0; i < Choices.Length; i++)
            {
                if (Choices[i - 1].GetType() == typeof(string))
                    result[i - 1] = (string)Choices[i - 1];
                else
                    result[i] = ((Step)Choices[i - 1]).Name;
            }
            return result;
        }
    }
}
