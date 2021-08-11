using ConsoleGUI.UserDefined;
using Prompton.Models;

namespace Prompton.UI.Views
{
    public class SeriesView : SimpleControl
    {
        private readonly Series _series;
        public SeriesView(Series series)
        {
            _series = series;
        }
    }
}
