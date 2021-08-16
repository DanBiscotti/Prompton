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

        var mainView = main.GetView();
        var inputListeners = mainView.GetListeners();

        ConsoleManager.Setup();
        ConsoleManager.Content = mainView;
        var exit = false;
        while (!exit)
        {
            Thread.Sleep(10);
            ConsoleManager.ReadInput(mainView.GetListeners());
        }
        // do final stuff
    }
}
