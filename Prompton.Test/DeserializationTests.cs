﻿using Prompton.Models;
using System.IO;
using Xunit;
using YamlDotNet.Serialization;

namespace Prompton.Test
{
    public class DeserializationTests
    {
        private const string SeriesFilePath = "TestFiles/series.yml";
        private const string ChoiceFilePath = "TestFiles/choice.yml";

        private string yaml;
        private IDeserializer deserializer;

        public DeserializationTests()
        {
            deserializer = new DeserializerBuilder()
                .WithTypeConverter(new StepRefConverter())
                .WithTagMapping("!main", typeof(Main))
                .WithTagMapping("!series", typeof(Series))
                .WithTagMapping("!choice", typeof(Choice))
                .WithTagMapping("!ref", typeof(StepReference))
                .Build();
        }

        [Fact]
        public void SeriesDeserializes()
        {
            yaml = File.ReadAllText(SeriesFilePath);
            var reader = new StringReader(yaml);
            var data = deserializer.Deserialize(reader);

            Assert.IsType<Series>(data);
            Assert.IsType<Series>(((Series)data).Steps[0]);
            Assert.IsType<StepReference>(((Series)data).Steps[1]);
        }

        [Fact]
        public void ChoiceDeserializes()
        {
            yaml = File.ReadAllText(ChoiceFilePath);
            var reader = new StringReader(yaml);
            var data = deserializer.Deserialize(reader);

            Assert.IsType<Choice>(data);
            Assert.IsType<Choice>(((Choice)data).Choices[0]);
            Assert.IsType<StepReference>(((Choice)data).Choices[1]);
        }
    }
}
