using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class SeriesView : StepView
{
    public Series Series { get; set; }

    public SeriesView(Series series)
    {
        Series = series;
        Content = new VerticalStackPanel()
        {
            Children = new IControl[]
            {
                BuildTextBox(series.Prompt),
                BuildTextBox("Press enter to continue"),
            }
        };
    }
}
