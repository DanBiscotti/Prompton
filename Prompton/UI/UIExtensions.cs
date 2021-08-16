using ConsoleGUI.Input;
using ConsoleGUI.UserDefined;
using Prompton.Steps;
using Prompton.UI.Listeners;
using Prompton.UI.Views;

namespace Prompton.UI;

public static class UIExtensions
{
    private static QuitListener quitListener = new();

    public static SimpleControl GetView(this Step step) =>
        step switch
        {
            ChoiceStep choice => new ChoiceView(choice),
            InputStep input => new InputView(input),
            MainStep main => new MainView(main),
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
            InputView inputView
              => new List<IInputListener> { new InputListener(inputView), quitListener },
            MainView mainView
              => new List<IInputListener> { new MainListener(mainView), quitListener },
            SeriesView seriesView
              => new List<IInputListener> { new SeriesListener(seriesView), quitListener },
            TimerView timerView
              => new List<IInputListener> { new TimerListener(timerView), quitListener },
            _
              => throw new NotSupportedException(
                  $"View type {stepView.GetType()} doesn't support listeners"
              )
        };
}
