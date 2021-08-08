using Prompton.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;
using Attribute = Terminal.Gui.Attribute;

namespace Prompton.UI.Views
{
    public class PromptonWindow : Window
    {
        private readonly Main main;
        private readonly Dictionary<string, Step> stepDict;

        private LinkedList<Step> orderedSteps;

        private ColorScheme colorScheme;

        public PromptonWindow(Main main, Dictionary<string, Step> stepDict)
        {
            this.main = main;
            this.stepDict = stepDict;
            colorScheme = new ColorScheme()
            {
                Normal = Attribute.Make(Color.DarkGray, Color.Black),
                Focus = Attribute.Make(Color.White, Color.Black),
                HotNormal = Attribute.Make(Color.BrightBlue, Color.Black),
                HotFocus = Attribute.Make(Color.Blue, Color.Black)
            };
            X = 0;
            Y = 0;
            Width = Dim.Fill();
            Height = Dim.Fill();

            orderedSteps = new LinkedList<Step>();
            orderedSteps.AddFirst(main);
        }

        private void HandleStep(LinkedListNode<Step> current)
        {
            switch (current.Value)
            {
                case Series series:
                    foreach (Step s in series.Steps.Reverse<Step>())
                    {
                        orderedSteps.AddAfter(current, s);
                    }
                    HandleStep(current.Next);
                    break;
                case Choice choice:
                    var list = new ListView(choice.GetDisplayNames());
                    // get users choice
                    // add after
                    // return
                    break;
            }
        }
    }
}
