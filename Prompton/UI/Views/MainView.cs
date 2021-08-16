using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;
using Figgle;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class MainView : SimpleControl
{
    private MainStep main;

    public MainView(MainStep main)
    {
        this.main = main;
        Content = new Border
        {
            Content = new Box
            {
                Content = new BreakPanel { Content = new TextBlock { Text = FiggleFonts.Standard.Render(main.Name) } },
                HorizontalContentPlacement = Box.HorizontalPlacement.Center,
                VerticalContentPlacement = Box.VerticalPlacement.Center
            }
        };
    }

    public void ChangeView(SimpleControl view)
    {
        Content = view;
    }
}
