using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class MainView : StepView
{
    public Main Main { get; }

    public MainView(Main main) : base(main)
    {
        Main = main;
        Content = BuildMainView();
    }

    private VerticalStackPanel BuildMainView()
    {
        var children = new List<IControl>();

        if (Main.Name is not null or "")
            children.Add(BuildTitle());

        if (Main.Prompt is not null or "")
            children.Add(BuildPrompt());

        children.Add(new HorizontalSeparator());
        children.Add(BuildPressEnter());

        return new VerticalStackPanel { Children = children };
    }

    private Box BuildTitle()
    {
        var figgle = Figgle.FiggleFonts.Standard.Render(Main.Name);
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
