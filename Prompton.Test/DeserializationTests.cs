using Prompton.Steps;
using Prompton.Yaml;
using Xunit;

namespace Prompton.Test;

public class DeserializationTests
{
    private const string SeriesFilePath = "TestFiles/series.yml";
    private const string StepRefFilePath = "TestFiles/stepref.yml";
    private const string TimerFilePath = "TestFiles/timer.yml";

    private StepSerializer deserializer;

    public DeserializationTests()
    {
        deserializer = new StepSerializer();
    }

    [Fact]
    public void SeriesDeserializes()
    {
        var data = deserializer.Deserialize(SeriesFilePath);

        Assert.IsType<Series>(data);
        var series = data as Series;
        Assert.Equal(3, series.Repeats);
    }

    [Fact]
    public void StepRefDeserializes()
    {
        var data = deserializer.Deserialize(StepRefFilePath);

        Assert.IsType<Ref>(data);
        var stepRef = data as Ref;
        Assert.Equal("test-ref", stepRef.ReferredStepId);
    }

    [Fact]
    public void TimerDeserializes()
    {
        var data = deserializer.Deserialize(TimerFilePath);

        Assert.IsType<Steps.Timer>(data);
        var timer = data as Steps.Timer;
    }
}
