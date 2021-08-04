using Prompton.Models;
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
        private YamlDeserializer deserializer;

        public DeserializationTests()
        {
            deserializer = new YamlDeserializer();
        }

        [Fact]
        public void ChoiceDeserializes()
        {
            var data = deserializer.Deserialize(ChoiceFilePath);

            Assert.IsType<Choice>(data);
        }

        [Fact]
        public void InputDeserializes()
        {
            var data = deserializer.Deserialize(ChoiceFilePath);

            Assert.IsType<Input>(data);
        }

        [Fact]
        public void MainDeserializes()
        {
            var data = deserializer.Deserialize(ChoiceFilePath);

            Assert.IsType<Main>(data);
        }

        [Fact]
        public void SeriesDeserializes()
        {
            var data = deserializer.Deserialize(SeriesFilePath);

            Assert.IsType<Series>(data);
        }

        [Fact]
        public void TimerDeserializes()
        {
            var data = deserializer.Deserialize(ChoiceFilePath);

            Assert.IsType<Timer>(data);
        }
    }
}
