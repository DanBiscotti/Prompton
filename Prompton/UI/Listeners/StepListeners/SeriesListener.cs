using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;
public class SeriesListener : StepListener
{
    private readonly SeriesView seriesView;
    private readonly SeriesResult seriesResult;

    public SeriesListener(SeriesView seriesView, UIProvider ui) : base(ui)
    {
        this.seriesView = seriesView;
        seriesResult = new SeriesResult
        {
            StepId = seriesView.Step.Id,
            Prompt = seriesView.Step.Prompt,
            Result = new List<StepResult>()
        };
    }

    public override StepResult GetResult() => seriesResult;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    foreach (var step in seriesView.Step.Steps)
                    {
                        var stepResult = ProcessStep(step);
                        seriesResult.Result.Add(stepResult);
                    }
                    seriesView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
