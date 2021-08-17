using Prompton.Steps;

namespace Prompton.UI.Views;

public class SeriesView : StepView
{
    public SeriesStep Series;

    public SeriesView(SeriesStep series) : base(series)
    {
        Series = series;
    }
}
