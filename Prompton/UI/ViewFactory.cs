﻿using ConsoleGUI;
using ConsoleGUI.Controls;
using Prompton.Steps;
using Prompton.UI.Views;
using NetCoreAudio;

namespace Prompton.UI;

public class ViewFactory
{
    private readonly Dictionary<string, Step> stepDict;
    private readonly Player audioPlayer;

    public ViewFactory(Dictionary<string, Step> stepDict, Player audioPlayer)
    {
        this.stepDict = stepDict;
        this.audioPlayer = audioPlayer;
    }

    public StepView Create(Step step) =>
        step switch
        {
            Choice choice => new ChoiceView(choice),
            Display choice => new DisplayView(choice),
            Main main => new MainView(main),
            Number number => new NumberView(number),
            Series series => new SeriesView(series),
            Ref stepRef => Create(stepDict[stepRef.ReferredStepId]),
            Text input => new TextView(input),
            Time timer => new TimeView(timer, audioPlayer),
            _
              => throw new NotSupportedException(
                  $"Step type {step.GetType()} does not have a corresponding view"
              )
        };

    public Popup CreatePopupView(string message, params string[] options) 
    {
        return new Popup(message, options);
    }
}
