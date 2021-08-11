﻿using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;

namespace Testing
{
    public class TestListener : IInputListener
    {
        private readonly int i;
        private readonly TestFlag flag;

        public TestListener(int i, TestFlag flag)
        {
            this.i = i;
            this.flag = flag;
        }

        public void OnInput(InputEvent inputEvent)
        {
            if (inputEvent.Key.Key == System.ConsoleKey.Enter)
            {
                ConsoleManager.Content = new TestView(i);
                var listener = new TestListener(i + 1, flag);
                while (!flag.Exit)
                {
                    inputEvent.Handled = true;
                    ConsoleManager.ReadInput(new[] { listener });
                }
            }
            else if(inputEvent.Key.Key == System.ConsoleKey.Q)
            {
                flag.Exit = true;
                inputEvent.Handled = true;
            }
        }
    }
}
