using ConsoleGUI.UserDefined;
using Prompton.Models;

namespace Prompton.UI.Views;

public class SeriesView : SimpleControl
{
    private readonly SeriesStep series;

    public SeriesView(SeriesStep series)
    {
        this.series = series;
    }
}
