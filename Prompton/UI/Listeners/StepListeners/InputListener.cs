using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class InputListener : StepListener
{
    private readonly InputView inputView;
    private readonly UIProvider ui;

    public InputListener(InputView inputView, UIProvider ui)
    {
        this.inputView = inputView;
        this.ui = ui;
    }

    public override StepResult GetResult()
    {
        throw new NotImplementedException();
    }

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    if(inputView.Validate())
                    {
                        inputView.Complete = true;
                    }
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
