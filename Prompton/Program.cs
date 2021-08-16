using Prompton;
using Prompton.Serialization;


// Deserialize & Validate
var deserializer = new YamlDeserializer();
App app = new App(deserializer);
app.Start();
