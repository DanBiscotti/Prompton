using System.Collections.Generic;
using System.IO;
using YamlDotNet.Core;
using YamlDotNet.Core.Events;
using YamlDotNet.Serialization;

public static class YamlSerializerExtensions
{
    public static IEnumerable<TItem> DeserializeMany<TItem>(
        this IDeserializer deserializer,
        string yaml)
    {
        var reader = new Parser(new StringReader(yaml));
        reader.Consume<StreamStart>();

        DocumentStart dummyStart;
        DocumentEnd dummyEnd;
        while (reader.TryConsume<DocumentStart>(out dummyStart))
        {
            var item = deserializer.Deserialize<TItem>(reader);
            yield return item;
            reader.TryConsume<DocumentEnd>(out dummyEnd);
        }
    }
}
