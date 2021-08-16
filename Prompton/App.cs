using ConsoleGUI;
using ConsoleGUI.Input;
using ConsoleGUI.UserDefined;
using Prompton.Steps;
using Prompton.UI.Listeners;
using Prompton.UI.Views;

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

public static class StepExtensions
{
    public static QuitListener quitListener = new QuitListener();

    public static SimpleControl GetView(this Step step) =>
        step switch
        {
            MainStep main => new MainView(main),
            ChoiceStep choice => new ChoiceView(choice),
            InputStep input => new InputView(input),
            SeriesStep series => new SeriesView(series),
            TimerStep timer => new TimerView(timer),
            _
              => throw new NotSupportedException(
                  $"Step type {step.GetType()} does not have a corresponding view"
              )
        };

    public static List<IInputListener> GetListeners(this SimpleControl stepView) =>
        stepView switch
        {
            ChoiceView choiceView
              => new List<IInputListener> { new ChoiceListener(choiceView), quitListener },
            _
              => throw new NotSupportedException(
                  $"View type {stepView.GetType()} doesn't support listeners"
              )
        };
}
