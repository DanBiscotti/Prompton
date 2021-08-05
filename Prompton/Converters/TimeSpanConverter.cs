using System;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Prompton.Converters
{
    public class TimeSpanConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(TimeSpan);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            parser.MoveNext();
            return new TimeSpan(); // TODO parse
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}