using Prompton.Models;
using Xunit;

namespace Prompton.Test.Deserialization
{
    public class InputTests
    {
        private const string InputFilePath = "TestFiles/Input/valid-input.yml";
        private YamlDeserializer deserializer;

        public InputTests()
        {
            deserializer = new YamlDeserializer();
        }

        [Fact]
        public void ValidInputDeserializes()
        {
            var data = deserializer.Deserialize(InputFilePath);

            Assert.IsType<Input>(data);
            var input = (Input)data;
            Assert.True(input.TextArea);
            Assert.True(input.Validate);
            Assert.Equal("test-regex", input.ValidationRegex.ToString());
            Assert.Equal("test-validation-message", input.ValidationMessage);
        }
    }
}
