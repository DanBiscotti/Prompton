using Prompton.Models;
using Prompton.UI.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terminal.Gui;

namespace Prompton
{
    public class App
    {
        private YamlDeserializer deserializer;

        public void Start(params string[] files)
        {
            var stepsWithIds = new Dictionary<string, Step>();
            var baseLinkedList = new LinkedList<Step>();
            var window = new PromptonWindow(baseLinkedList, stepsWithIds);
            
            Application.Init();
            var top = Application.Top;
        }
    }
}
