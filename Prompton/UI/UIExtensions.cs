using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Listeners;
using Prompton.UI.Views;

namespace Prompton.UI;

public static class UIExtensions
{
    private static QuitListener quitListener = new();

    public static StepView GetView(this Step step, Dictionary<string, Step> stepDict) =>
        step switch
        {
            ChoiceStep choice => new ChoiceView(choice),
            InputStep input => new InputView(input),
            MainStep main => new MainView(main),
            SeriesStep series => new SeriesView(series),
            StepReference stepRef => stepDict[stepRef.ReferredStepId].GetView(stepDict),
            TimerStep timer => new TimerView(timer),
            _
              => throw new NotSupportedException(
                  $"Step type {step.GetType()} does not have a corresponding view"
              )
        };

    public static List<IInputListener> GetListeners(this StepView stepView, Flag flag, Margin viewArea, Dictionary<string, Step> stepDict) =>
        stepView switch
        {
            ChoiceView choiceView
              => new List<IInputListener> { new ChoiceListener(choiceView, flag, viewArea, stepDict), quitListener },
            InputView inputView
              => new List<IInputListener> { new InputListener(inputView, flag, viewArea, stepDict), quitListener },
            MainView mainView
              => new List<IInputListener> { new MainListener(mainView, flag, viewArea, stepDict), quitListener },
            SeriesView seriesView
              => new List<IInputListener> { new SeriesListener(seriesView, flag, viewArea, stepDict), quitListener },
            TimerView timerView
              => new List<IInputListener> { new TimerListener(timerView, flag), quitListener },
            _
              => throw new NotSupportedException(
                  $"View type {stepView.GetType()} doesn't support listeners"
              )
        };
}
