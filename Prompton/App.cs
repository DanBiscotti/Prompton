using Prompton.Models;
using Prompton.UI.Views;
using System.Collections.Generic;
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
            var window = new PromptonWindow(baseLinkedList, stepsWithIds);

            Application.Init();
            var top = Application.Top;
            top.Add(window);
        }
    }
}
