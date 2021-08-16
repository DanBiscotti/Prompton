using ConsoleGUI.UserDefined;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class SeriesView : SimpleControl
{
    private readonly SeriesStep series;

    public SeriesView(SeriesStep series)
    {
        this.series = series;
    }
}
