using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;
using Prompton.Models;
using System;

namespace Prompton.UI.Views
{
    public class MainView : SimpleControl
    {
        private Main main;

        public MainView(Main main)
        {
            this.main = main;
            Content = new Border { Content = new TextBlock() { Text = main.Name } };
        }

        public void ChangeView(SimpleControl view)
        {
            Content = view;
        }
    }
}
