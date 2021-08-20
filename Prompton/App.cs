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

        var viewFactory = new ViewFactory(stepDict);
        var listenerFactory = new ListenerFactory();
        var ui = new UIProvider(viewFactory, listenerFactory);
        var view = ui.GetView(main);
        ui.ViewArea.Content = view;
        var listeners = ui.GetListeners(view);

        ui.Init();
        while (!ui.Flag.Next && !ui.Flag.Quit)
        {
            Thread.Sleep(10);
            ConsoleManager.ReadInput(listeners);
        }

        // do final stuff
    }
}
