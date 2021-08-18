using Prompton.Steps;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
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
        var referredStepId = parser.Current as Scalar;
        parser.MoveNext();
        return new StepReference { ReferredStepId = referredStepId.Value };
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        throw new NotImplementedException();
    }
}