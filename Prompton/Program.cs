using Prompton.Models;
using System.Collections.Generic;
using Terminal.Gui;


// Deserialize & Validate
var main = new Main { Id = "test-main", Name = "Test Routine", Prompt = "Welcome to the Test Routine" };
var series = new Series { Id = "test-series", Name = "Test Series", Prompt = "You are now in a series" };
var choice = new Choice { Id = "test-series", Name = "Test Choice", Prompt = "Make a choice:", Choices = new() { "choice 1", "choice 2" } };

main.Steps = new List<Step> { series, choice };




Application.Init();


var top = Application.Top;
// Creates the top-level window to show
var win = new Window("MyApp")
{
    X = 0,
    Y = 0, // Leave one row for the toplevel menu
    // By using Dim.Fill(), it will automatically resize without manual intervention
    Width = Dim.Fill(),
    Height = Dim.Fill()
};

//TODO: Duplicated code in Demo.cs Consider moving to shared assembly
var items = new List<string>() { "hsladkf", "sdfkjdsahf" };

var listview = new ListView(items)
{
    X = Pos.Center(),
    Y = Pos.Center(),
    Height = Dim.Fill(2),
    Width = Dim.Fill(2),
};
win.Add(listview);

top.Add(win);

Application.Run();