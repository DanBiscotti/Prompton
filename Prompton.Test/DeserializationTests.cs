using Prompton.Models;
using Xunit;

namespace Prompton.Test
{
    public class DeserializationTests
    {
        private const string SeriesFilePath = "TestFiles/series.yml";
        private const string StepRefFilePath = "TestFiles/stepref.yml";
        private const string TimerFilePath = "TestFiles/timer.yml";
        
        private YamlDeserializer deserializer;

        public DeserializationTests()
        {
            deserializer = new YamlDeserializer();
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
