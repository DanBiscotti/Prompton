using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;

namespace Testing
{
    public class TestView : SimpleControl
    {
        public TestView(int i)
        {
            Content = new Border { Content = new TextBlock { Text = $"test {i}" } };
        }
    }
}
