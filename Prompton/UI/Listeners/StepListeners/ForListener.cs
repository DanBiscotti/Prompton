using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;
public class ForListener : StepListener
{
    private readonly ForView forView;
    private readonly ForResult result;

    public ForListener(ForView forView, UIProvider ui) : base(ui)
    {
        this.forView = forView;
        result = new ForResult
        {
            StepId = forView.Step.Id,
            Result = new List<StepResult>()
        };
    }

    public override StepResult GetResult() => result;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    result.Prompt = forView.Step.Prompt;

                    var repeats = forView.Step.Repeats;

                    if (forView.Step.PromptForRepeats)
                    {
                        var numberStep = new Number { Prompt = $"Enter a number of times to repeat: {forView.Step.Prompt}" };
                        var numberResult = ProcessStep(numberStep) as NumberResult;
                        repeats = (int)numberResult.Result;
                    }

                    for (int i = 0; i < repeats; i++)
                    {
                        if(repeats > 1)
                        {
                            var displayStep = new Display { Prompt = $"{forView.Step.Prompt}: round {i + 1}/{repeats}" };
                            var _ = ProcessStep(displayStep);
                        }

                        var stepResult = ProcessStep(forView.Step.Step);
                        result.Result.Add(stepResult);
                    }

                    if (forView.Step.PromptForRepeats)
                        result.Repeats = repeats;

                    forView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
