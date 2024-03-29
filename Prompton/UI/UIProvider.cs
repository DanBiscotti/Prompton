﻿using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using ConsoleGUI.Space;
using Prompton.Steps;
using Prompton.UI.Listeners;
using Prompton.UI.Views;
using System.Collections.Generic;
using System.Threading;

namespace Prompton.UI;

public class UIProvider
{
    private readonly ViewFactory viewFactory;
    private readonly ListenerFactory listenerFactory;
    private readonly QuitListener quitListener;

    private readonly Canvas canvas;

    public Margin ViewArea { get; }

    public UIProvider(ViewFactory viewFactory, ListenerFactory listenerFactory)
    {
        this.viewFactory = viewFactory;
        this.listenerFactory = listenerFactory;

        canvas = new Canvas();
        ViewArea = new Margin
        {
            Offset = new Offset(5, 2, 5, 2)
        };
    }

    public void Init()
    {
        canvas.Add(ViewArea, new Rect(0, 0, ConsoleManager.WindowSize.Width - 2, ConsoleManager.WindowSize.Height - 2));
        ConsoleManager.Setup();
        ConsoleManager.Content = new Background
        {
            Content = new Border
            {
                Content = canvas
            }
        };
    }

    public StepView GetView(Step step)
    {
        return viewFactory.Create(step);
    }

    public Dictionary<string, IInputListener> GetListeners(StepView view)
    {
        var listeners = new Dictionary<string, IInputListener> { { Constants.StepListenerKey, listenerFactory.Create(view, this) } };
        if (view is TextView i)
            listeners["textbox"] = i.TextBox;
        else if(view is NumberView n)
            listeners["textbox"] = n.TextBox;
        return listeners;
    }

    public void DisplayPopup(string message)
    {
        var popup = viewFactory.CreatePopupView(message);
        var width = message.Length + 20;
        var height = 10;
        var left = ((ConsoleManager.WindowSize.Width - 2) / 2) - (width / 2);
        var top = ((ConsoleManager.WindowSize.Height - 2) / 2) - (height / 2);

        canvas.Add(popup, new Rect(left, top, width, height));
        var listener = listenerFactory.CreatePopupListener(popup);
        while (!popup.Complete)
        {
            Thread.Sleep(10);
            ConsoleManager.ReadInput(new[] { listener });
        }
    }
}
