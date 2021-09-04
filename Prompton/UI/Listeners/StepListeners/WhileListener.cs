using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;
public class WhileListener : StepListener
{
    private readonly WhileView whileView;
    private readonly WhileResult result;

    public WhileListener(WhileView whileView, UIProvider ui) : base(ui)
    {
        this.whileView = whileView;
        result = new WhileResult
        {
            StepId = whileView.Step.Id,
            Prompt = whileView.Step.Prompt,
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
                    var breakLoop = false;
                    var repeats = 0;
                    while (!breakLoop)
                    {
                        repeats++;

                        var stepResult = ProcessStep(whileView.Step.Step);
                        result.Result.Add(stepResult);

                        var choiceStep = new Choice
                        {
                            Prompt = $"Would you like to repeat again: {whileView.Step.Prompt} (current count: {repeats})",
                            Choices = new() { { "Yes", null }, { "No", null } }
                        };
                        var choiceResult = ProcessStep(choiceStep) as ChoiceResult;
                        breakLoop = choiceResult.Choice == "No";
                    }
                    result.Repeats = repeats;

                    whileView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
