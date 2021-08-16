using ConsoleGUI;
using Prompton.Steps;
using Prompton.UI;

var step = new MainStep
{
    Id = "main",
    Name = "Test Main",
    Prompt = "Welcome to Test",
    Repeats = 2,
    Steps = new List<Step>() { }
};

var view = step.GetView();
var listeners = view.GetListeners();

ConsoleManager.Setup();
ConsoleManager.Content = view;

while (true)
{
    Thread.Sleep(10);
    ConsoleManager.ReadInput(listeners);
}