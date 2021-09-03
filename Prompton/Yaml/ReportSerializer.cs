using Prompton.Steps.StepResults;
using Prompton.Yaml.Converters;
using YamlDotNet.Serialization;

namespace Prompton.Yaml;

public interface IYamlSerializer
{
    string Serialize(MainResult main);
}

public class ReportSerializer : IYamlSerializer
{
    private ISerializer serializer;
    private static List<Type> TypesWithTags = new()
    {
        typeof(MainResult),
        typeof(ChoiceResult),
        typeof(DisplayResult),
        typeof(ForResult),
        typeof(WhileResult),
        typeof(TextResult),
        typeof(NumberResult),
        typeof(SeriesResult),
        typeof(TimerResult),
        typeof(DateOnly),
        typeof(TimeOnly),
        typeof(TimeSpan)
    };

    public ReportSerializer()
    {
        serializer = BuildSerializer();
    }

    public string Serialize(MainResult main)
    {
        return serializer.Serialize(main);
    }

    private ISerializer BuildSerializer()
    {
        var builder = new SerializerBuilder()
            .DisableAliases()
            .EnsureRoundtrip()
            .WithTypeConverter(new DateOnlyConverter())
            .WithTypeConverter(new TimeOnlyConverter())
            .WithTypeConverter(new TimeSpanConverter())
            .WithTypeInspector(x => new OrderedTypeInspector(x));

        foreach (var type in TypesWithTags)
        {
            builder = builder.WithTagMapping($"!{type.Name}", type);
        }

        return builder.Build();
    }
}
