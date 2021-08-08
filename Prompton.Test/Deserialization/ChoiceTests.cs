﻿using Prompton.Models;
using Xunit;

namespace Prompton.Test.Deserialization
{
    public class ChoiceTests
    {
        private const string ChoiceFilePath = "TestFiles/Choice/valid-choice.yml";
        private YamlDeserializer deserializer;

        public ChoiceTests()
        {
            deserializer = new YamlDeserializer();
        }

        [Fact]
        public void ValidChoiceDeserializes()
        {
            var data = deserializer.Deserialize(ChoiceFilePath);

            Assert.IsType<Choice>(data);

            var choices = ((Choice)data).GetDisplayNames();
            Assert.Equal("yes", choices[0]);
            Assert.Equal("no", choices[1]);
        }
    }
}
