using ConsoleGUI;
using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class MainListener : StepListener
{
    private readonly MainView mainView;
    private readonly MainResult result;

    public MainListener(MainView mainView, UIProvider ui) : base(ui)
    {
        this.mainView = mainView;
        result = MainResult.Create(mainView.Step.Id, mainView.Step.Name, mainView.Step.Tags);
    }

    public override StepResult GetResult()
    {
        result.Duration = DateTime.UtcNow - result.StartDateUtc.ToDateTime(result.StartTimeUtc, DateTimeKind.Utc);
        return result;
    }

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    result.Result = ProcessStep(mainView.Step);
                    mainView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
