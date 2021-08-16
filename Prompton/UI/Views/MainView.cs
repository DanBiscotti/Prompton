using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;
using Prompton.Models;

namespace Prompton.UI.Views;

public class MainView : SimpleControl
{
    private MainStep main;

    public MainView(MainStep main)
    {
        this.main = main;
        Content = new Border { Content = new TextBlock() { Text = main.Name } };
    }

    public void ChangeView(SimpleControl view)
    {
        Content = view;
    }
}
