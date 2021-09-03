using Prompton.Steps;
using Prompton.Yaml.Converters;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

namespace Prompton.Yaml;

public interface IYamlDeserializer
{

}

public class StepSerializer : IYamlDeserializer
{
    private IDeserializer deserializer;
    private List<string> ids;
    private static List<Type> TypesWithTags = new()
    {
        typeof(Main),
        typeof(Choice),
        typeof(Display),
        typeof(For),
        typeof(While),
        typeof(Text),
        typeof(Number),
        typeof(Steps.Random),
        typeof(Series),
        typeof(Time),
        typeof(Ref),
        typeof(Regex),
        typeof(TimeSpan)
    };

    public StepSerializer()
    {
        ids = new List<string>();
        deserializer = BuildDeserializer();
    }

    public Step Deserialize(string yaml)
    {
        return deserializer.Deserialize<Step>(yaml);
    }

    public IEnumerable<Step> DeserializeMany(string yaml)
    {
        return deserializer.DeserializeMany<Step>(yaml);
    }

    private IDeserializer BuildDeserializer()
    {
        var builder = new DeserializerBuilder()
            .WithTypeConverter(new RegexConverter())
            .WithTypeConverter(new StepRefConverter(ids))
            .WithTypeConverter(new TimeSpanConverter());

        foreach (var type in TypesWithTags)
        {
            builder = builder.WithTagMapping($"!{type.Name}", type);
        }

        return builder.Build();
    }
}
