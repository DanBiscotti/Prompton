using ConsoleGUI;
using Prompton.Steps;
using Prompton.UI;
using System.Text.RegularExpressions;

//var timestring1 = TimeSpan.FromSeconds(37).ToString(@"hh\:mm\:ss");
//var timestring2 = TimeSpan.FromSeconds(103).ToString(@"hh\:mm\:ss");

//var list = Testing.TestingFiggle.GetList();

//string time1;
//string time2;

//foreach (var font in list)
//{
//    time1 = font(timestring1);
//    time2 = font(timestring2);
//    var width1 = time1.IndexOf('\n') + 1;
//    var width2 = time2.IndexOf('\n') + 1;
//    if (width1 == width2)
//    {
//        Console.Write(time2);
//        Console.WriteLine(list.IndexOf(font));
//        Console.ReadKey();
//    }
//}

var input = new InputStep
{
    Id = "input",
    Prompt = "How are you today?",
    ValidationRegex = new Regex(@"[0-9]*$"),
    ValidationMessage = "Must be a number"
};

var timer = new TimerStep
{
    Id = "timer",
    Prompt = "Timing!",
    Countdown = new TimeSpan(0, 0, 10),
    Countup = false,
    Limit = new TimeSpan(0, 0, 20)
};

var stepDict = new Dictionary<string, Step> 
{ 
    { "input", input },
    { "timer", timer }
};

var choice = new ChoiceStep
{
    Id = "choice",
    Prompt = "What type of step would you like to test?",
    Choices = new Dictionary<string, Step> { 
        { "Input", new StepReference { ReferredStepId = "input" } }, 
        { "Timer", new StepReference { ReferredStepId = "timer" } }, 
        { "Display", null } }
};

var main = new MainStep
{
    Id = "main",
    Name = "Recommended Routine",
    Prompt = "Welcome to Test",
    Repeats = 2,
    Steps = new List<Step>() { choice }
};

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