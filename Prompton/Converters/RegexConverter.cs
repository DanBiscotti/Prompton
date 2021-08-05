using System;
using System.Text.RegularExpressions;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Prompton.Converters
{
    public class RegexConverter : IYamlTypeConverter
    {
        public bool Accepts(Type type)
        {
            return type == typeof(Regex);
        }

        public object ReadYaml(IParser parser, Type type)
        {
            parser.MoveNext();
            return new Regex(""); // TODO parse
        }

        public void WriteYaml(IEmitter emitter, object value, Type type)
        {
            throw new NotImplementedException();
        }
    }
}