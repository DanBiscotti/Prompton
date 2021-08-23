using Prompton.Steps;
using Prompton.Yaml;
using Xunit;

namespace Prompton.Test.Deserialization;

public class ChoiceTests
{
    private const string ChoiceFilePath = "TestFiles/Choice/valid-choice.yml";
    private StepSerializer deserializer;

    public ChoiceTests()
    {
        deserializer = new StepSerializer();
    }

    [Fact]
    public void ValidChoiceDeserializes()
    {
        var data = deserializer.Deserialize(ChoiceFilePath);

        Assert.IsType<Choice>(data);
        var step = data as Choice;
        var choices = step.Choices.Keys.ToList();
        Assert.Equal("Yes", choices[0]);
        Assert.Equal("No", choices[1]);
    }
}
