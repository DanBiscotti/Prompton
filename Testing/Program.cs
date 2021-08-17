using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Space;
using Prompton.Steps;
using Prompton.UI;

var main = new MainStep
{
    Id = "main",
    Name = "Recommended Routine",
    Prompt = "Welcome to Test",
    Repeats = 2,
    Steps = new List<Step>() { }
};

var viewArea = new Margin
{
    Offset = new Offset(5, 2, 5, 2)
};
var view = main.GetView();
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
var listeners = view.GetListeners(flag, viewArea);
while (!flag.Next && !flag.Quit)
{
    Thread.Sleep(10);
    ConsoleManager.ReadInput(listeners);
}