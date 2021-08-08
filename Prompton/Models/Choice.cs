using System.Collections.Generic;
using YamlDotNet.Serialization;
using System;

namespace Prompton.Models
{
    public class Choice : Step
    {
        [YamlMember(Alias = "choices")]
        public List<object> Choices;

        public List<string> GetDisplayNames()
        {
            var result = new List<string>();
            for (int i = 0; i < Choices.Count; i++)
            {
                switch (Choices[i])
                {
                    case string s:
                        result.Add(s);
                        break;
                    case StepReference step:
                        result.Add(step.Name);
                        break;
                    case Step step:
                        result.Add(step.Name);
                        break;
                    default:
                        throw new ArgumentException();
                }
            }
            return result;
        }
    }
}
