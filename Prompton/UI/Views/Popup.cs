using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;

namespace Prompton.UI.Views;

public class Popup : SimpleControl
{
    private string[] options;
    private HorizontalStackPanel buttonArea;
    private int selectedButton;

    public bool Complete {  get; set; }

    public Popup(string message, params string[] options)
    {
        buttonArea = new HorizontalStackPanel();
        Content = new Background()
        {
            Content = new Border
            {
                Content = new Box
                {
                    HorizontalContentPlacement = Box.HorizontalPlacement.Center,
                    VerticalContentPlacement = Box.VerticalPlacement.Center,
                    Content = new VerticalStackPanel
                    {
                        Children = new IControl[]
                        {
                            new TextBlock { Text = message },
                            new HorizontalSeparator(),
                            buttonArea
                        }
                    }
                }
            }
        };
        Refresh();
    }

    public void Scroll(bool up)
    {
        if (up && selectedButton > 0)
            selectedButton--;
        if (!up && selectedButton < options.Length - 1)
            selectedButton++;
        Refresh();
    }

    private void Refresh()
    {
        var buttons = options is null || options.Length == 0
            ? new[] { new Button { Content = new TextBlock { Text = "Ok" } } }.ToList()
            : options.Select(o => new Button { Content = new TextBlock { Text = o } }).ToList();

        buttonArea.Children = buttons;
    }
}
