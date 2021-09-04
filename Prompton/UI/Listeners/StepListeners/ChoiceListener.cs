using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class ChoiceListener : StepListener
{
    private readonly ChoiceView choiceView;
    private readonly ChoiceResult result;

    public ChoiceListener(ChoiceView choiceView, UIProvider ui) : base(ui)
    {
        this.choiceView = choiceView;
        result = new ChoiceResult { StepId = choiceView.Step.Id, Prompt = choiceView.Step.Prompt };
    }

    public override StepResult GetResult() => result;

    public override void OnInput(InputEvent inputEvent)
    
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    result.Choice = choiceView.GetSelectedString();
                    var step = choiceView.GetSelectedStep(result.Choice);
                    if (step is not null)
                    {
                        var stepResult = ProcessStep(step);
                        result.Result = stepResult;
                    }
                    choiceView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
            case ConsoleKey.J
            or ConsoleKey.K
            or ConsoleKey.DownArrow
            or ConsoleKey.UpArrow:
                {
                    choiceView.Scroll(inputEvent.Key.Key is ConsoleKey.K or ConsoleKey.UpArrow);
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
