using Prompton.Steps;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Prompton.Yaml.Converters;

public class StepRefConverter : IYamlTypeConverter
{
    public bool Accepts(Type type)
    {
        return type == typeof(StepReference);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        parser.MoveNext();
        return new StepReference();
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        throw new NotImplementedException();
    }
}