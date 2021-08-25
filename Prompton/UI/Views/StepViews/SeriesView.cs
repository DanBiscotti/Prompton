﻿using Prompton.Steps;

namespace Prompton.UI.Views;

public class SeriesView : StepView
{
    public Series Series;

    public SeriesView(Series series) : base(series)
    {
        Series = series;
    }

    // TODO: add a view which just shows Prompt
}
