using ConsoleGUI;
using Prompton.Yaml;
using Prompton.UI;

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

        var flag = new Flag { Next = false, Quit = false };
        var view = main.GetView();
        var listeners = view.GetListeners(flag, null);

        ConsoleManager.Setup();
        ConsoleManager.Content = view;

        while (!flag.Next && !flag.Quit)
        {
            Thread.Sleep(10);
            ConsoleManager.ReadInput(listeners);
        }
        // do final stuff
    }
}
