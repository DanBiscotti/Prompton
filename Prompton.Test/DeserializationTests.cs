using Prompton.Steps;
using Prompton.Yaml;
using Xunit;

namespace Prompton.Test;

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

        Assert.IsType<SeriesStep>(data);
        var series = data as SeriesStep;
        Assert.Equal(3, series.Repeats);
    }

    [Fact]
    public void StepRefDeserializes()
    {
        var data = deserializer.Deserialize(StepRefFilePath);

        Assert.IsType<StepReference>(data);
        var stepRef = data as StepReference;
        Assert.Equal("test-ref", stepRef.ReferredStepId);
    }

    [Fact]
    public void TimerDeserializes()
    {
        var data = deserializer.Deserialize(TimerFilePath);

        Assert.IsType<TimerStep>(data);
        var timer = data as TimerStep;
    }
}
