using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;
using System.Collections.Generic;

namespace Prompton.UI.Views;

public class MainView : StepView
{
    public Main Step { get; }

    public MainView(Main step)
    {
        Step = step;
        Content = BuildMainView();
    }

    private VerticalStackPanel BuildMainView()
    {
        var children = new List<IControl>();

        if (Step.Name is not null or "")
            children.Add(BuildTitle());

        if (Step.Prompt is not null or "")
            children.Add(BuildTextBox(Step.Prompt));

        children.Add(new HorizontalSeparator());
        children.Add(BuildTextBox("Press enter to begin"));

        return new VerticalStackPanel { Children = children };
    }

    private Box BuildTitle()
    {
        var figgle = Figgle.FiggleFonts.Standard.Render(Step.Name);
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
}
