using Prompton.Models;
using System.Collections.Generic;
using System.Linq;
using Terminal.Gui;

namespace Prompton.UI.Views
{
    public static class StepUiExtensions
    {
        public static View GetView(this Choice input)
        {
            var items = input.GetDisplayNames();
            var listview = new ListView(items)
            {
                X = Pos.Center(),
                Y = Pos.Center(),
                Height = Dim.Fill(2),
                Width = Dim.Fill(2),
            };
            listview.OpenSelectedItem += args => { };
            return listview;
        }
    }
}
