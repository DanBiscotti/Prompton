using System.Text.RegularExpressions;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

namespace Prompton.Yaml.Converters;

public class RegexConverter : IYamlTypeConverter
{
    public bool Accepts(Type type)
    {
        return type == typeof(Regex);
    }

    public object ReadYaml(IParser parser, Type type)
    {
        var regexString = parser.Current as Scalar;
        parser.MoveNext();
        return new Regex(regexString.Value);
    }

    public void WriteYaml(IEmitter emitter, object value, Type type)
    {
        throw new NotImplementedException(); // TODO: implement
    }
}