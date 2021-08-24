﻿using ConsoleGUI;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI;
using Prompton.UI.Listeners;
using Prompton.Yaml;
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

var input = new Text
{
    Id = "input",
    Prompt = "How are you today?",
    ValidationRegex = new Regex(@"[0-9]*$"),
    ValidationMessage = "Must be a number"
};

var timer = new Prompton.Steps.Timer
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

var choice = new Choice
{
    Id = "choice",
    Prompt = "What type of step would you like to test?",
    Choices = new Dictionary<string, Step> { 
        { "Input", new Ref { ReferredStepId = "input" } }, 
        { "Timer", new Ref { ReferredStepId = "timer" } }, 
        { "Display", null } }
};

var main = new Main
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
    ConsoleManager.ReadInput(listeners.Select(x => x.Value).ToArray());
}
var listener = listeners["step-listener"] as StepListener;
var result = listener.GetResult() as MainResult;

var serializer = new ReportSerializer();
var yaml = serializer.Serialize(result);