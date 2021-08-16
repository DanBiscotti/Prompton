using ConsoleGUI.UserDefined;
using Prompton.Models;

namespace Prompton.UI.Views;

public class InputView : SimpleControl {

    private InputStep input;

    public InputView(InputStep input) {
        this.input = input;
    }
}
