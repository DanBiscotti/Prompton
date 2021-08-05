using Prompton.Converters;
using Prompton.Models;
using System;
using System.Collections.Generic;
using System.IO;
using YamlDotNet.Serialization;

namespace Prompton
{
    public class YamlDeserializer
    {
        private IDeserializer validator;
        private IDeserializer deserializer;
        private static Dictionary<string, Type> TagMappings = new()
        {
            { "!main", typeof(Main) },
            { "!ref", typeof(StepReference) },
            { "!choice", typeof(Choice) },
            { "!input", typeof(Input) },
            { "!series", typeof(Series) },
            { "!timer", typeof(Timer) },
        };

        public YamlDeserializer()
        {
            validator = BuildValidator();
            deserializer = BuildDeserializer();
        }

        public ValidationError[] Validate(string[] filepaths)
        {
            var errors = new List<ValidationError>();
            foreach (var filepath in filepaths)
            {
                var exists = true; // TODO
                if (exists)
                    errors.AddRange(Validate(filepath));
            }
            return errors.ToArray();
        }

        public ValidationError[] Validate(string filepath)
        {
            var yaml = File.ReadAllText(filepath);
            var reader = new StringReader(yaml);
            //Todo
            return Array.Empty<ValidationError>();
        }

        public Step Deserialize(params string[] filepaths)
        {
            //Todo
            return new Main();
        }

        private IDeserializer BuildValidator()
        {
            var builder = new DeserializerBuilder();
            foreach (var mapping in TagMappings)
            {
                builder = builder.WithTagMapping(mapping.Key, mapping.Value);
            }
            return builder.Build();
        }

        private IDeserializer BuildDeserializer()
        {
            var builder = new DeserializerBuilder()
                .WithTypeConverter(new StepRefConverter());
            foreach (var mapping in TagMappings)
            {
                builder = builder.WithTagMapping(mapping.Key, mapping.Value);
            }
            return builder.Build();
        }
    }

    public class ValidationError
    {
        public string Message { get; set; }
        public string Location { get; set; }
    } 
}
