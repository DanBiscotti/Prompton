using ConsoleGUI;
using Prompton.Yaml;
using Prompton.UI;
using ConsoleGUI.Controls;
using ConsoleGUI.Space;

namespace Prompton;

public class App
{
    private IYamlDeserializer deserializer;

    public App(IYamlDeserializer deserializer)
    {
        this.deserializer = deserializer;
    }

    public void Start(params string[] files)
    {
        var stepDict = deserializer.GetStepDictionary();
        var main = deserializer.GetMain();

        var viewArea = new Margin
        {
            Offset = new Offset(5, 2, 5, 2)
        };

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
        // do final stuff
    }
}
