using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using ConsoleGUI.UserDefined;
using System;
using System.Collections.Generic;

namespace Prompton.UI.Views
{
    public class ChoiceView : SimpleControl
    {
        private int selected = 0;
        private List<string> items;

        public ChoiceView(List<string> items)
        {
            this.items = items;
            Refresh();
        }

        public void Scroll(bool up)
        {
            if (up && selected > 0)
                selected--;
            if(!up && selected < items.Count - 1)
                selected++;
            Refresh();
        }

        private void Refresh()
        {
            var stack = new VerticalStackPanel();
            for (int i = 0; i < items.Count; i++)
            {
                stack.Add(new Background
                {
                    Color = i == selected ? ConsoleColor.White : ConsoleColor.Black,
                    Content = new TextBlock
                    {
                        Color = i == selected ? ConsoleColor.Black : ConsoleColor.White,
                        Text = items[i]
                    }
                });
            }
            Content = stack;
        }
    }

    public class ChoiceListener : IInputListener
    {
        private readonly ChoiceView selectMenu;

        public ChoiceListener(ChoiceView selectMenu)
        {
            this.selectMenu = selectMenu;
        }

        public void OnInput(InputEvent inputEvent)
        {
            if(inputEvent.Key.Key is ConsoleKey.J or ConsoleKey.K)
            {
                selectMenu.Scroll(inputEvent.Key.Key == ConsoleKey.K);
                inputEvent.Handled = true;
            }
        }
    }
}
