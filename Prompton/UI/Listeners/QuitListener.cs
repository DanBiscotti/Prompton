using ConsoleGUI.Input;
using Prompton.Models;
using Prompton.UI.Views;
using System;
using System.Collections.Generic;

namespace Prompton.UI.Listeners
{
    public class QuitListener : IInputListener
    {
        private readonly ChoiceView selectMenu;

        public QuitListener(ChoiceView selectMenu, LinkedListNode<Step> currentStep, NextFlag flag, object resultMap)
        {
            this.selectMenu = selectMenu;
        }

        public void OnInput(InputEvent inputEvent)
        {
            switch (inputEvent.Key.Key)
            {
                case ConsoleKey.Enter:
                    {
                        break;
                    }
                case ConsoleKey.J or ConsoleKey.K:
                    {
                        selectMenu.Scroll(inputEvent.Key.Key == ConsoleKey.K);
                        inputEvent.Handled = true;
                        return;
                    }
            }
        }
    }
}