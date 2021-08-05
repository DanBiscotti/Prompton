using Prompton.Models;
using System.IO;
using Xunit;
using YamlDotNet.Serialization;

namespace Prompton.Test
{
    public class DeserializationTests
    {
        private const string ChoiceFilePath = "TestFiles/choice.yml";
        private const string InputFilePath = "TestFiles/input.yml";
        private const string MainFilePath = "TestFiles/main.yml";
        private const string SeriesFilePath = "TestFiles/series.yml";
        private const string StepRefFilePath = "TestFiles/stepref.yml";
        private const string TimerFilePath = "TestFiles/timer.yml";

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

            var choices = ((Choice)data).GetDisplayNames();
            Assert.Equal("yes", choices[0]);
            Assert.Equal("no", choices[1]);
        }

        [Fact]
        public void InputDeserializes()
        {
            var data = deserializer.Deserialize(InputFilePath);

            Assert.IsType<Input>(data);
            var input = (Input)data;
            Assert.True(input.TextArea);
            Assert.True(input.Validate);
            Assert.Equal("test-regex", input.ValidationRegex.ToString());
            Assert.Equal("test-validation-message", input.ValidationMessage);
        }

        [Fact]
        public void MainDeserializes()
        {
            var data = deserializer.Deserialize(MainFilePath);

            Assert.IsType<Main>(data);
        }

        [Fact]
        public void SeriesDeserializes()
        {
            var data = deserializer.Deserialize(SeriesFilePath);

            Assert.IsType<Series>(data);
            var series = (Series)data;
            Assert.Equal(3, series.Repeats);
        }

        [Fact]
        public void StepRefDeserializes()
        {
            var data = deserializer.Deserialize(StepRefFilePath);

            Assert.IsType<StepReference>(data);
        }

        [Fact]
        public void TimerDeserializes()
        {
            var data = deserializer.Deserialize(TimerFilePath);

            Assert.IsType<Timer>(data);
        }
    }
}
