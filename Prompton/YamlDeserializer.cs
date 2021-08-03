using Prompton.Models;
using System;
using System.Collections.Generic;
using YamlDotNet.Serialization;

namespace Prompton
{
    public class YamlDeserializer
    {
        private IDeserializer deserializer;
        private static Dictionary<string, Type> TagMappings = new()
        {
            { "!main", typeof(Main) },
            { "!ref", typeof(StepReference) },
            { "!series", typeof(Series) },
            { "!choice", typeof(Choice) },
            { "!timer", typeof(Timer) },
        };

        public YamlDeserializer()
        {
            var builder = new DeserializerBuilder()
                .WithTypeConverter(new StepRefConverter());

            foreach (var mapping in TagMappings) {  
                builder = builder.WithTagMapping(mapping.Key, mapping.Value);
            }
        }

        public Step[] GetAllSteps(params string[] filenames)
        {

        }
    }
}
