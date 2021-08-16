using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Prompton.Serialization.Converters;

public class TimeSpanConverter : IYamlTypeConverter
{
    public bool Accepts(Type type)
    {
        return type == typeof(TimeSpan);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        var timespanString = parser.Current as Scalar;
        parser.MoveNext();
        return TimeSpan.Parse(timespanString.Value);
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        throw new NotImplementedException();
    }
}