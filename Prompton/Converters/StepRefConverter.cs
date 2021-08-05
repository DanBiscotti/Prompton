using Prompton.Models;
using System;
using YamlDotNet.Core;
using YamlDotNet.Serialization;

namespace Prompton.Converters
{
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
}
