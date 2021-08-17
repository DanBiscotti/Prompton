using Prompton;
using Prompton.Yaml;


// Deserialize & Validate
var deserializer = new YamlDeserializer();
App app = new App(deserializer);
app.Start();
