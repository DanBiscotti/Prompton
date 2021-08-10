using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;
using Prompton.Models;
using System;
using System.Collections.Generic;

namespace Prompton.UI.Views
{
    public class ChoiceView : SimpleControl
    {
        private int selected = 0;
        private Choice input;
        private List<string> displayText;

        public ChoiceView(Choice input)
        {
            this.input = input;
            displayText = input.GetDisplayNames();
            Refresh();
        }

        public void Scroll(bool up)
        {
            if (up && selected > 0)
                selected--;
            if (!up && selected < input.Choices.Count - 1)
                selected++;
            Refresh();
        }

        public object GetSelected()
        {
            return input.Choices[selected];
        }

        private void Refresh()
        {
            var stack = new VerticalStackPanel();
            for (int i = 0; i < input.Choices.Count; i++)
            {
                stack.Add(new Background
                {
                    Color = i == selected ? ConsoleColor.White : ConsoleColor.Black,
                    Content = new TextBlock
                    {
                        Color = i == selected ? ConsoleColor.Black : ConsoleColor.White,
                        Text = displayText[i]
                    }
                });
            }
            Content = stack;
        }
    }
}