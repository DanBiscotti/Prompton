﻿using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class SeriesView : StepView
{
    public Series Step { get; set; }

    public SeriesView(Series step)
    {
        Step = step;
        Content = new VerticalStackPanel()
        {
            Children = new IControl[]
            {
                BuildTextBox(step.Prompt),
                BuildTextBox("Press enter to continue"),
            }
        };
    }
}
