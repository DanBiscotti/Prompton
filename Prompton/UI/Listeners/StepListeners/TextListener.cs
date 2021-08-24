using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class TextListener : StepListener
{
    private readonly TextView textView;
    private readonly UIProvider ui;

    public TextListener(TextView textView, UIProvider ui)
    {
        this.textView = textView;
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
                    if(textView.Validate())
                    {
                        textView.Complete = true;
                    }
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
