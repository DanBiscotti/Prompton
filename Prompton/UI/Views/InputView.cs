using Prompton.Steps;

namespace Prompton.UI.Views;

public class InputView : StepView {

    private InputStep input;

    public InputView(InputStep input) : base(input)
    {
        this.input = input;
    }
}
