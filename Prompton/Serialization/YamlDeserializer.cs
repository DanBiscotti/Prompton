using Prompton.Serialization.Converters;
using Prompton.Steps;
using System.Text.RegularExpressions;
using YamlDotNet.Serialization;

namespace Prompton.Serialization;

public interface IYamlDeserializer
{
    Dictionary<string, Step> GetStepDictionary(params string[] filepaths);
    MainStep GetMain(params string[] filepaths);
}

public class YamlDeserializer : IYamlDeserializer
{
    private IDeserializer validator;
    private IDeserializer deserializer;
    private static Dictionary<string, Type> TagMappings =
        new()
        {
            { "!main", typeof(MainStep) },
            { "!choice", typeof(ChoiceStep) },
            { "!input", typeof(InputStep) },
            { "!series", typeof(SeriesStep) },
            { "!timer", typeof(TimerStep) },
            { "!stepref", typeof(StepReference) },
            { "!regex", typeof(Regex) },
            { "!timespan", typeof(TimeSpan) }
        };

    public YamlDeserializer()
    {
        validator = BuildValidator();
        deserializer = BuildDeserializer();
    }

    public ValidationError[] Validate(string[] filepaths)
    {
        var errors = new List<ValidationError>();
        foreach (var filepath in filepaths)
        {
            var exists = true; // TODO
            if (exists)
                errors.AddRange(Validate(filepath));
        }
        return errors.ToArray();
    }

    public ValidationError[] Validate(string filepath)
    {
        var yaml = File.ReadAllText(filepath);
        var reader = new StringReader(yaml);
        //Todo
        return Array.Empty<ValidationError>();
    }

    public Dictionary<string, Step> GetStepDictionary(params string[] filepaths)
    {
        return new Dictionary<string, Step>();
    }

    public MainStep GetMain(params string[] filepaths)
    {
        return new MainStep();
    }

    public Step Deserialize(string filepath)
    {
        var yaml = File.ReadAllText(filepath);
        var reader = new StringReader(yaml);
        return deserializer.Deserialize<Step>(reader);
    }
    private IDeserializer BuildValidator()
    {
        var builder = new DeserializerBuilder();
        foreach (var mapping in TagMappings)
        {
            builder = builder.WithTagMapping(mapping.Key, mapping.Value);
        }
        return builder.Build();
    }

    private IDeserializer BuildDeserializer()
    {
        var builder = new DeserializerBuilder().WithTypeConverter(new RegexConverter())
            .WithTypeConverter(new StepRefConverter())
            .WithTypeConverter(new TimeSpanConverter());

        foreach (var mapping in TagMappings)
        {
            builder = builder.WithTagMapping(mapping.Key, mapping.Value);
        }

        return builder.Build();
    }
}

public class ValidationError
{
    public string Message { get; set; }
    public string Location { get; set; }
}
