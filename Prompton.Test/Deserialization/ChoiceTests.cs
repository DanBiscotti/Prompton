using Prompton.Steps;
using Prompton.Yaml;
using Xunit;

namespace Prompton.Test.Deserialization;

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

        Assert.IsType<ChoiceStep>(data);
        var step = data as ChoiceStep;
        var choices = step.Choices.Keys.ToList();
        Assert.Equal("yes", choices[0]);
        Assert.Equal("no", choices[1]);
    }
}
