using ConsoleGUI;
using Prompton;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI;
using Prompton.UI.Listeners;
using Prompton.Yaml;
using SharpAudio;

var mainFilePath = args[0];
var mainYamlString = File.ReadAllText(mainFilePath);

var stepSerializer = new StepSerializer();
var main = stepSerializer.Deserialize(mainYamlString) as Main;

Dictionary<string, Step> stepDict = default;
if (main.DefinitionsDir is not null or "")
{
    var filenames = Directory.GetFiles(main.DefinitionsDir);
    var yamlStrings = filenames.Select(x => File.ReadAllText(x)).ToList();
    var steps = yamlStrings.SelectMany(x => stepSerializer.DeserializeMany(x)).ToList();
    stepDict = steps.ToDictionary(k => k.Id, v => v);
}

var validator = new StepValidator();
// TODO: A exit if invalid

var viewFactory = new ViewFactory(stepDict, AudioEngine.CreateDefault());
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

var listener = listeners[Constants.StepListenerKey] as StepListener;
var result = listener.GetResult() as MainResult;

var serializer = new ReportSerializer();
var resultYaml = serializer.Serialize(result);



var datetimeStringForFilename = $"{main.Id}_{result.StartDateUtc:yyyy-MM-dd}T{result.StartTimeUtc:HH-mm-ss}Z";

File.WriteAllText($"{main.ResultsDir}/{datetimeStringForFilename}.yml", resultYaml);