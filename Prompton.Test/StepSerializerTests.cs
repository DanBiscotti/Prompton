using Prompton.Steps;
using Prompton.Yaml;
using System.IO;
using System.Linq;
using Xunit;

namespace Prompton.Test;

public class StepSerializerTests
{
    private const string NumberFilePath = "TestFiles/number.yml";
    private const string TextFilePath = "TestFiles/text.yml";
    private const string MainFilePath = "TestFiles/main.yml";
    private const string ChoiceFilePath = "TestFiles/choice.yml";
    private const string SeriesFilePath = "TestFiles/series.yml";
    private const string StepRefFilePath = "TestFiles/stepref.yml";
    private const string RandomFilePath = "TestFiles/random.yml";
    private const string TimeFilePath = "TestFiles/timer.yml";

    private StepSerializer deserializer;

    public StepSerializerTests()
    {
        deserializer = new StepSerializer();
    }

    [Fact]
    public void SeriesDeserializes()
    {
        var yaml = File.ReadAllText(SeriesFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Series>(data);
        var series = data as Series;
    }

    [Fact]
    public void StepRefDeserializes()
    {
        var yaml = File.ReadAllText(StepRefFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Ref>(data);
        var stepRef = data as Ref;
        Assert.Equal("test-ref", stepRef.ReferredStepId);
    }

    [Fact]
    public void TimeDeserializes()
    {
        var yaml = File.ReadAllText(TimeFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Time>(data);
        var timer = data as Time;
    }

    [Fact]
    public void ChoiceDeserializes()
    {
        var yaml = File.ReadAllText(ChoiceFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Choice>(data);
        var step = data as Choice;
        var choices = step.Choices.Keys.ToList();
        Assert.Equal("Yes", choices[0]);
        Assert.Equal("No", choices[1]);
    }

    [Fact]
    public void MainDeserializes()
    {
        var yaml = File.ReadAllText(MainFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Main>(data);

        var step = data as Main;
    }

    [Fact]
    public void TextDeserializes()
    {
        var yaml = File.ReadAllText(TextFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Text>(data);
        var input = data as Text;
        Assert.Equal("test-regex", input.ValidationRegex.ToString());
        Assert.Equal("test-validation-message", input.ValidationMessage);
    }

    [Fact]
    public void NumberDeserializes()
    {
        var yaml = File.ReadAllText(NumberFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Number>(data);
        var number = data as Number;
        Assert.Equal(3, number.Min);
        Assert.Equal(7, number.Max);
    }

    [Fact]
    public void RandomDeserializes()
    {
        var yaml = File.ReadAllText(RandomFilePath);

        var data = deserializer.Deserialize(yaml);

        Assert.IsType<Steps.Random>(data);
    }
}
