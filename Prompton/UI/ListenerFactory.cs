using ConsoleGUI.Input;
using Prompton.UI.Listeners;
using Prompton.UI.Views;
using System;

namespace Prompton.UI;

public class ListenerFactory
{
    public IInputListener Create(StepView stepView, UIProvider provider) => stepView switch
    {
        ChoiceView choiceView
          => new ChoiceListener(choiceView, provider),
        DisplayView displayView
          => new DisplayListener(displayView, provider),
        ForView forView
          => new ForListener(forView, provider),
        WhileView whileView
          => new WhileListener(whileView, provider),
        TextView inputView
          => new TextListener(inputView, provider),
        MainView mainView
          => new MainListener(mainView, provider),
        NumberView numberView
          => new NumberListener(numberView, provider),
        SeriesView seriesView
          => new SeriesListener(seriesView, provider),
        TimeView timerView
          => new TimeListener(timerView),
        _
          => throw new NotSupportedException(
              $"View type {stepView.GetType()} doesn't support listeners"
          )
    };

    public IInputListener CreatePopupListener(Popup popup) => new PopupListener(popup);
}
