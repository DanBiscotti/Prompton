﻿using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;
public class SeriesListener : IInputListener
{
    private readonly SeriesView seriesView;
    private readonly UIProvider ui;

    public SeriesListener(SeriesView seriesView, UIProvider ui)
    {
        this.seriesView = seriesView;
        this.ui = ui;
    }

    public void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    foreach (var step in seriesView.Series.Steps)
                    {
                        var view = ui.GetView(step);
                        var listeners = ui.GetListeners(view);
                        ui.ViewArea.Content = view;
                        ui.Flag.Next = false;
                        while (!ui.Flag.Next && !ui.Flag.Quit)
                        {
                            Thread.Sleep(10);
                            ConsoleManager.ReadInput(listeners);
                        }
                    }
                    ui.Flag.Next = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
