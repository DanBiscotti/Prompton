using Prompton.Models;
using System.IO;
using Xunit;
using YamlDotNet.Serialization;

namespace Prompton.Test
{
    public class ConverterTests
    {
        private string yaml;
        private IDeserializer deserializer;

        public ConverterTests()
        {
            yaml = File.ReadAllText("TestFiles/series.yml");
            deserializer = new DeserializerBuilder()
                .WithTypeConverter(new StepRefConverter())
                .WithTagMapping("!main", typeof(Main))
                .WithTagMapping("!series", typeof(Series))
                .WithTagMapping("!choice", typeof(Choice))
                .WithTagMapping("!ref", typeof(StepReference))
                .Build();
        }

        [Fact]
        public void Blah()
        {
            var reader = new StringReader(yaml);
            var data = deserializer.Deserialize(reader);
        }
    }
}
