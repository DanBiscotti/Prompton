using Prompton.Steps;

namespace Prompton.UI.Views;

public class TimerView : StepView
{

    private readonly TimerStep timer;

    public TimerView(TimerStep timer) : base(timer)
    {
        this.timer = timer;
    }
}
