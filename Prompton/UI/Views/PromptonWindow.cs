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
        public LinkedList<Step> OrderedSteps;
        public Dictionary<string, Step> LinkedSteps;

        public ColorScheme colorScheme;

        public PromptonWindow(LinkedList<Step> orderedSteps, Dictionary<string, Step> linkedSteps)
        {
            OrderedSteps = orderedSteps;
            LinkedSteps = linkedSteps;
            colorScheme = new ColorScheme()
            {
                Normal = Attribute.Make(Color.DarkGray, Color.Black),
                Focus = Attribute.Make(Color.White, Color.Black),
                HotNormal = Attribute.Make(Color.BrightBlue, Color.Black),
                HotFocus = Attribute.Make(Color.Blue, Color.Black)
            };
        }

        public LinkedListNode<Step> ProcessStep(LinkedList<Step> steps, LinkedListNode<Step> current)
        {
            var switcher = new Dictionary<Type, Func<LinkedListNode<Step>>>()
            {
                { typeof(Series), () => {
                    foreach(Step s in ((Series)current.Value).Steps.Reverse<Step>()) {
                        steps.AddAfter(current, s);
                    }
                    return current.Next; }
                },
                // add in choice and others
            };
            return switcher[current.Value.GetType()]();
        }
    }
}
