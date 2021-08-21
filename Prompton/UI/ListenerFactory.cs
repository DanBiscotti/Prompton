using ConsoleGUI.Input;
using Prompton.UI.Listeners;
using Prompton.UI.Views;

namespace Prompton.UI;

public class ListenerFactory
{
    public IInputListener Create(StepView stepView, UIProvider provider) => stepView switch
    {
        ChoiceView choiceView
          => new ChoiceListener(choiceView, provider),
        InputView inputView
          => new InputListener(inputView, provider),
        MainView mainView
          => new MainListener(mainView, provider),
        SeriesView seriesView
          => new SeriesListener(seriesView, provider),
        TimerView timerView
          => new TimerListener(timerView, provider),
        _
          => throw new NotSupportedException(
              $"View type {stepView.GetType()} doesn't support listeners"
          )
    };

    public IInputListener CreatePopupListener(Popup popup) => new PopupListener(popup);
}
