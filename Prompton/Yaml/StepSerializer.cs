using Prompton.Steps;
using Prompton.Yaml.Converters;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

namespace Prompton.Yaml;

public interface IYamlDeserializer
{
    Dictionary<string, Step> GetStepDictionary(params string[] filepaths);
    Main GetMain(params string[] filepaths);
}

public class StepSerializer : IYamlDeserializer
{
    private IDeserializer deserializer;
    private List<string> ids;
    private static List<Type> TypesWithTags = new()
    {
        typeof(Main),
        typeof(Choice),
        typeof(Input),
        typeof(Series),
        typeof(Steps.Timer),
        typeof(Ref),
        typeof(Regex),
        typeof(TimeSpan)
    };

    public StepSerializer()
    {
        ids = new List<string>();
        deserializer = BuildDeserializer();
    }

    public Dictionary<string, Step> GetStepDictionary(params string[] filepaths)
    {
        return new Dictionary<string, Step>();
    }

    public Main GetMain(params string[] filepaths)
    {
        return new Main();
    }

    public Step Deserialize(string filepath)
    {
        var yaml = File.ReadAllText(filepath);
        var reader = new StringReader(yaml);
        return deserializer.Deserialize<Step>(reader);
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
