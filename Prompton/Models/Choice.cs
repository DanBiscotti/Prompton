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
                    case string str:
                        result.Add(str);
                        break;
                    case StepReference step:
                        result.Add(step.Step.Name);
                        break;
                    case Step step:
                        result.Add(step.Name);
                        break;
                    default:
                        throw new ArgumentException(
                            $"unsupported choice type: {Choices[i].GetType()} in choice step id: {Id}"
                        );
                }
            }
            return result;
        }
    }
}
