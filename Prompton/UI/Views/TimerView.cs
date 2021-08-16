using ConsoleGUI.UserDefined;
using Prompton.Models;

namespace Prompton.UI.Views;

public class TimerView : SimpleControl
{

    private readonly TimerStep timer;

    public TimerView(TimerStep timer)
    {
        this.timer = timer;
    }
}
