using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Prompton.Yaml.Converters;

public class DateOnlyConverter : IYamlTypeConverter
{
    public bool Accepts(Type type)
    {
        return type == typeof(DateOnly);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        throw new NotImplementedException();
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        var date = (DateOnly)value;
        emitter.Emit(new Scalar(date.ToString("yyyy-MM-dd")));
    }
}
