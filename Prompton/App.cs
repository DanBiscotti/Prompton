using ConsoleGUI;
using ConsoleGUI.Input;
using ConsoleGUI.UserDefined;
using Prompton.Models;
using Prompton.UI.Views;
using System.Collections.Generic;
using System.Threading;

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
            var currentStep = orderedSteps.First;

            var exit = false;
            var flag = new NextFlag();
            ConsoleManager.Setup();
            ConsoleManager.Content = new MainView(main);
            var inputListeners = new List<IInputListener>();

            var resultMap = new object();
            var viewProvider = new ViewProvider();
            var listenerProvider = new ListenerProvider();

            while (!exit)
            {
                Thread.Sleep(10);
                ConsoleManager.ReadInput(inputListeners);
                if (flag.MoveNext)
                {
                    if (currentStep.Next is not null)
                    {
                        currentStep = currentStep.Next;
                        var view = viewProvider.GetView(currentStep.Value);
                        ConsoleManager.Content = view;
                        inputListeners = listenerProvider.GetListeners(view, currentStep, flag, resultMap);
                    }
                    else
                    {
                        exit = true;
                    }
                }
            }

            // do final stuff
            // write result map to yaml file
        }
    }

    public class ListenerProvider
    {
        public ListenerProvider()
        {
        }

        public List<IInputListener> GetListeners(SimpleControl view, LinkedListNode<Step> currentStep, NextFlag flag, object resultMap)
        {
            //switch on currentStep.Value.GetType
            //instantiate appropriate listener
            throw new System.NotImplementedException();
        }
    }

    public class ViewProvider
    {
        public ViewProvider()
        {
        }

        public SimpleControl GetView(Step value)
        {
            throw new System.NotImplementedException();
        }
    }

    public class NextFlag
    {
        public bool MoveNext { get; set; } = false;
    }
}
