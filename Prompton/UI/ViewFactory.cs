using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;
using Prompton.UI.Views;

namespace Prompton.UI;

public class ViewFactory
{
    private readonly Dictionary<string, Step> stepDict;

    public ViewFactory(Dictionary<string, Step> stepDict)
    {
        this.stepDict = stepDict;
    }

    public StepView Create(Step step) =>
        step switch
        {
            Choice choice => new ChoiceView(choice),
            Text input => new TextView(input),
            Main main => new MainView(main),
            Number number => new NumberView(number),
            Series series => new SeriesView(series),
            Ref stepRef => Create(stepDict[stepRef.ReferredStepId]),
            Steps.Time timer => new TimeView(timer),
            _
              => throw new NotSupportedException(
                  $"Step type {step.GetType()} does not have a corresponding view"
              )
        };

    public Popup CreatePopupView(string message, params string[] options) 
    {
        return new Popup(message, options);
    }
}
