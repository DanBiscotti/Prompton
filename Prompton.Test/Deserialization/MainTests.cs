using Prompton.Serialization;
using Prompton.Steps;
using Xunit;

namespace Prompton.Test.Deserialization
{
    public class MainTests
    {
        private const string MainFilePath = "TestFiles/Main/valid-main.yml";
        private YamlDeserializer deserializer;

        public MainTests()
        {
            deserializer = new YamlDeserializer();
        }

        [Fact]
        public void ValidMainDeserializes()
        {
            var data = deserializer.Deserialize(MainFilePath);

            Assert.IsType<MainStep>(data);

            var Main = ((MainStep)data);
        }
    }
}
