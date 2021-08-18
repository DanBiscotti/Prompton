using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Space;
using Prompton.Steps;
using Prompton.UI;

var choice = new ChoiceStep
{
    Id = "choice",
    Name = "Choice",
    Prompt = "What is the capital of England?",
    Choices = new Dictionary<string, Step> { { "London", null }, { "Paris", null }, { "Skegness", null } }
};

var main = new MainStep
{
    Id = "main",
    Name = "Recommended Routine",
    Prompt = "Welcome to Test",
    Repeats = 2,
    Steps = new List<Step>() { choice }
};

var viewArea = new Margin
{
    Offset = new Offset(5, 2, 5, 2)
};

var stepDict = new Dictionary<string, Step>();

var view = main.GetView(stepDict);
viewArea.Content = view;
ConsoleManager.Setup();
ConsoleManager.Content = new Background
{
    Content = new Border
    {
        Content = viewArea
    }
};

var flag = new Flag { Next = false, Quit = false };
var listeners = view.GetListeners(flag, viewArea, stepDict);
while (!flag.Next && !flag.Quit)
{
    Thread.Sleep(10);
    ConsoleManager.ReadInput(listeners);
}