using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;

namespace Prompton.UI.Listeners;

public class TextListener : StepListener
{
    private readonly TextView textView;
    private readonly UIProvider ui;
    private readonly TextResult result;

    public TextListener(TextView textView, UIProvider ui)
    {
        this.textView = textView;
        this.ui = ui;
        result = new TextResult { Prompt = textView.TextStep.Prompt };
    }

    public override StepResult GetResult() => result;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    if(textView.Validate())
                    {
                        result.Result = textView.TextBox.Text;
                        textView.Complete = true;
                    }
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
