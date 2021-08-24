using Prompton.Steps;
using Prompton.Yaml;
using Xunit;

namespace Prompton.Test.Deserialization;

public class InputTests
{
    private const string InputFilePath = "TestFiles/Input/valid-input.yml";
    private StepSerializer deserializer;

    public InputTests()
    {
        deserializer = new StepSerializer();
    }

    [Fact]
    public void ValidInputDeserializes()
    {
        var data = deserializer.Deserialize(InputFilePath);

        Assert.IsType<Text>(data);
        var input = data as Text;
        Assert.Equal("test-regex", input.ValidationRegex.ToString());
        Assert.Equal("test-validation-message", input.ValidationMessage);
    }
}
