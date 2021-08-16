using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Space;
using ConsoleGUI.UserDefined;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class MainView : SimpleControl
{
    private MainStep main;
    public Margin ViewArea { get; }

    public MainView(MainStep main)
    {
        this.main = main;

        ViewArea = new Margin
        {
            Offset = new Offset(5, 2, 5, 2)
        };

        ViewArea.Content = BuildMainView();

        Content = new Background
        {
            Content = new Border
            {
                Content = ViewArea
            }
        };
    }

    private VerticalStackPanel BuildMainView()
    {
        var children = new List<IControl>();

        if (main.Name is not null or "")
            children.Add(BuildTitle());

        if (main.Prompt is not null or "")
            children.Add(BuildPrompt());

        children.Add(new HorizontalSeparator());
        children.Add(BuildPressEnter());

        return new VerticalStackPanel { Children = children };
    }

    private Box BuildPrompt()
    {
        return new Box
        {
            Content = new TextBlock
            {
                Text = main.Prompt
            }
        };
    }

    private Box BuildTitle()
    {
        var figgle = Figgle.FiggleFonts.Standard.Render(main.Name);
        var width = figgle.IndexOf('\n') + 1;
        var title = new TextBlock { Text = figgle };
        return new Box
        {
            Content = new Boundary
            {
                Width = width,
                Content = new Background
                {
                    Content = new WrapPanel
                    {
                        Content = new Boundary
                        {
                            MinWidth = width,
                            Content = title
                        }
                    }
                }
            }
        };
    }

    private Box BuildPressEnter()
    {
        return new Box
        {
            Content = new TextBlock { Text = "Press enter to begin" },
            HorizontalContentPlacement = Box.HorizontalPlacement.Center,
            VerticalContentPlacement = Box.VerticalPlacement.Center
        };
    }
}
