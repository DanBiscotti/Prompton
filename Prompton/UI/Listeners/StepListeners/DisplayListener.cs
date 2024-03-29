﻿using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using Prompton.Steps;
using Prompton.Steps.StepResults;
using Prompton.UI.Views;
using System;

namespace Prompton.UI.Listeners;
public class DisplayListener : StepListener
{
    private readonly DisplayView displayView;
    private readonly DisplayResult displayResult;
    private readonly UIProvider ui;

    public DisplayListener(DisplayView displayView, UIProvider ui)
    {
        this.displayView = displayView;
        this.ui = ui;
        displayResult = new DisplayResult
        {
            StepId = displayView.Step.Id,
            Prompt = displayView.Step.Prompt,
        };
    }

    public override StepResult GetResult() => displayResult;

    public override void OnInput(InputEvent inputEvent)
    {
        switch (inputEvent.Key.Key)
        {
            case ConsoleKey.Enter:
                {
                    displayView.Complete = true;
                    inputEvent.Handled = true;
                    return;
                }
        }
    }
}
