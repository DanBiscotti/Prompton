using ConsoleGUI;
using Prompton;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI;
using Prompton.UI.Listeners;
using Prompton.Yaml;

var mainFilePath = "test.yml";
var mainYamlString = File.ReadAllText(mainFilePath);

var stepSerializer = new StepSerializer();
var main = stepSerializer.Deserialize(mainYamlString) as Main;

Dictionary<string, Step> stepDict = default;
if (main.DefinitionsDir is not null or "")
{
    var filenames = Directory.GetFiles(main.DefinitionsDir);
    var yamlStrings = filenames.Select(x => File.ReadAllText(x)).ToList(); 
    var steps = yamlStrings.Select(x => stepSerializer.Deserialize(x)).ToList();
    stepDict = steps.ToDictionary(k => k.Id, v => v);
}

var validator =new StepValidator();
// TODO: A exit if invalid

var viewFactory = new ViewFactory(stepDict);
var listenerFactory = new ListenerFactory();
var ui = new UIProvider(viewFactory, listenerFactory);
var view = ui.GetView(main);
var listeners = ui.GetListeners(view);
ui.ViewArea.Content = view;

ui.Init();
while (!view.Complete)
{
    Thread.Sleep(10);
    ConsoleManager.ReadInput(listeners.Select(x => x.Value).ToArray());
}

var listener = listeners["step-listener"] as StepListener;
var result = listener.GetResult() as MainResult;

var serializer = new ReportSerializer();
var yaml = serializer.Serialize(result);

// TODO: 1 timer result inverted
// TODO: 2 when timer is countup seems to start at 2
// TODO: 3 Prompt missing on text and input
// TODO: 4 step which just displays some text

var x = 1;