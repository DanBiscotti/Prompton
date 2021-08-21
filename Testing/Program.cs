using ConsoleGUI;
using Prompton.Steps;
using Prompton.UI;
using System.Text.RegularExpressions;

var choice = new ChoiceStep
{
    Id = "choice",
    Prompt = "What is the capital of England?",
    Choices = new Dictionary<string, Step> { { "London", null }, { "Paris", null }, { "Skegness", null } }
};

var input = new InputStep
{
    Id = "input",
    Prompt = "How are you today?",
    ValidationRegex = new Regex(@"/[0-9]*/"),
    ValidationMessage = "Must be a number"
};

var main = new MainStep
{
    Id = "main",
    Name = "Recommended Routine",
    Prompt = "Welcome to Test",
    Repeats = 2,
    Steps = new List<Step>() { input }
};
var stepDict = new Dictionary<string, Step>();

var viewFactory = new ViewFactory(stepDict);
var listenerFactory = new ListenerFactory();
var ui = new UIProvider(viewFactory, listenerFactory);
var view = ui.GetView(main);
ui.ViewArea.Content = view;
var listeners = ui.GetListeners(view);

ui.Init();
while (!view.Complete)
{
    Thread.Sleep(10);
    ConsoleManager.ReadInput(listeners);
}