using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Prompton.Yaml.Converters;

public class TimeOnlyConverter : IYamlTypeConverter
{
    public bool Accepts(Type type)
    {
        return type == typeof(TimeOnly);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        throw new NotImplementedException(); // TODO: B implement
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        var time = (TimeOnly)value;
        emitter.Emit(new Scalar(time.ToString("HH:mm:ss")));
    }
}
