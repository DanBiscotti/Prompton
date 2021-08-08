using Prompton.Models;
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

            Assert.IsType<Main>(data);

            var Main = ((Main)data);
        }
    }
}
