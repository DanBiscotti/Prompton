using ConsoleGUI.UserDefined;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class SeriesView : SimpleControl
{
    public SeriesStep Series;

    public SeriesView(SeriesStep series)
    {
        Series = series;
    }
}
