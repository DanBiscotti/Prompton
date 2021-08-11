using ConsoleGUI.Input;
using Prompton.Models;
using Prompton.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prompton.UI.Listeners
{
    public class SeriesListener : IInputListener
    {
        private readonly SeriesView seriesView;
        private readonly LinkedListNode<Step> currentStep;
        private readonly NextFlag flag;
        private readonly object resultMap;

        public SeriesListener(SeriesView seriesView, LinkedListNode<Step> currentStep, NextFlag flag, object resultMap)
        {
            this.seriesView = seriesView;
            this.currentStep = currentStep;
            this.flag = flag;
            this.resultMap = resultMap;
        }

        public void OnInput(InputEvent inputEvent)
        {
            switch (inputEvent.Key.Key)
            {
                case ConsoleKey.Enter:
                    {
                        var list = currentStep.List;
                        var series = currentStep.Value as Series;
                        foreach(var step in series.Steps.Reverse<Step>())
                        {
                             list.AddAfter(currentStep, step);
                        }
                        // TODO: add new seriesresult to result map
                        flag.MoveNext = true;
                        inputEvent.Handled = true;
                        break;
                    }
            }
        }
    }
}