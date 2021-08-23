using Prompton;
using Prompton.Yaml;


// Deserialize & Validate
var deserializer = new StepSerializer();
App app = new App(deserializer);
app.Start();
