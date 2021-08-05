using System.Collections.Generic;
using Terminal.Gui;


Application.Init();

var colorScheme = new ColorScheme()
{
    Normal = Attribute.Make(Color.DarkGray, Color.Black),
    Focus = Attribute.Make(Color.White, Color.Black),
    HotNormal = Attribute.Make(Color.BrightBlue, Color.Black),
    HotFocus = Attribute.Make(Color.Blue, Color.Black)
};

var top = Application.Top;
// Creates the top-level window to show
var win = new Window("MyApp")
{
    X = 0,
    Y = 0, // Leave one row for the toplevel menu
    ColorScheme = colorScheme,
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