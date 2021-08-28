using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;
using Prompton.Steps;

namespace Prompton.UI.Views
{
    public class StepView : SimpleControl
    {
        public bool Complete { get; set; }

        protected static Box BuildTextBox(string text, ConsoleColor colour = ConsoleColor.White)
        {
            return new Box
            {
                Content = new TextBlock
                {
                    Text = text,
                    Color = colour,
                },
                VerticalContentPlacement = Box.VerticalPlacement.Center,
                HorizontalContentPlacement = Box.HorizontalPlacement.Center,
            };
        }
    }
}
