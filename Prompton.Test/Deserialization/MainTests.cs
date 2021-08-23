using Prompton.Steps;
using Prompton.Yaml;
using Xunit;

namespace Prompton.Test.Deserialization;

public class MainTests
{
    private const string MainFilePath = "TestFiles/Main/valid-main.yml";
    private StepSerializer deserializer;

    public MainTests()
    {
        deserializer = new StepSerializer();
    }

    [Fact]
    public void ValidMainDeserializes()
    {
        var data = deserializer.Deserialize(MainFilePath);

        Assert.IsType<Main>(data);

        var step = data as Main;
    }
}
