using ConsoleGUI.Input;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;

public class NumberListener : StepListener
{
    private readonly NumberView numberView;
    private readonly UIProvider ui;
    private readonly NumberResult result;

    public NumberListener(NumberView numberView, UIProvider ui)
    {
        this.numberView = numberView;
        this.ui = ui;
        result = new NumberResult
        {
            StepId = numberView.Step.Id,
            Prompt = numberView.Step.Prompt
        };
    }

    public override StepResult GetResult() => result;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    if (numberView.Validate())
                    {
                        result.Result = double.Parse(numberView.TextBox.Text);
                        numberView.Complete = true;
                    }
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
