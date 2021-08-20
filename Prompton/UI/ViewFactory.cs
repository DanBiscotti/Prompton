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
            ChoiceStep choice => new ChoiceView(choice),
            InputStep input => new InputView(input),
            MainStep main => new MainView(main),
            SeriesStep series => new SeriesView(series),
            StepReference stepRef => Create(stepDict[stepRef.ReferredStepId]),
            TimerStep timer => new TimerView(timer),
            _
              => throw new NotSupportedException(
                  $"Step type {step.GetType()} does not have a corresponding view"
              )
        };
}
