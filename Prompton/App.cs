using Prompton.UI.Views;
using Terminal.Gui;

namespace Prompton
{
    public class App
    {
        private IYamlDeserializer deserializer;

        public App(IYamlDeserializer deserializer)
        {
            this.deserializer = deserializer;
        }

        public void Start(params string[] files)
        {
            var stepsWithIds = deserializer.GetStepDictionary();
            var main = deserializer.GetMain();

            Application.Init();
            var top = Application.Top;
            var window = new PromptonWindow(main, stepsWithIds);
            top.Add(window);
            Application.Run();
        }
    }
}
