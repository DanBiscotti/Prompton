using Prompton.Steps;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Prompton.Yaml.Converters;

public class StepRefConverter : IYamlTypeConverter
{
    List<string> ids;

    public StepRefConverter(List<string> ids)
    {
        this.ids = ids;
    }

    public bool Accepts(Type type)
    {
        return type == typeof(Ref);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        var referredStepId = parser.Current as Scalar;
        parser.MoveNext();
        ids.Add(referredStepId.Value);
        return new Ref { ReferredStepId = referredStepId.Value };
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        throw new NotImplementedException();
    }
}