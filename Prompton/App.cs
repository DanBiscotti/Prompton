using Prompton.Models;
using System.Collections.Generic;

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

            var orderedSteps = new LinkedList<Step>();
            orderedSteps.AddFirst(main);
        }
    }
}
