using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Prompton.Models
{
    public class Choice : Step
    {
        [YamlMember(Alias = "choices")]
        public List<object> Choices;

        public string[] GetDisplayNames()
        {
            string[] result = new string[Choices.Length];
            for (int i = 0; i < Choices.Length; i++)
            {
                if (Choices[i].GetType() == typeof(string))
                    result[i] = (string)Choices[i];
                else
                    result[i] = ((Step)Choices[i]).Name;
            }
            return result;
        }
    }
}
