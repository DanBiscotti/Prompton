using ConsoleGUI;
using ConsoleGUI.Input;
using ConsoleGUI.UserDefined;
using Prompton.Models;
using Prompton.UI.Views;
using System.Collections.Generic;
using System.Threading;
using System.Linq;

namespace Prompton
{
    public class App
    {
        private IYamlDeserializer deserializer;
        private ViewProvider viewProvider;
        private ListenerProvider listenerProvider;

        public App(IYamlDeserializer deserializer)
        {
            this.deserializer = deserializer;
            viewProvider = new ViewProvider();
            listenerProvider = new ListenerProvider();
        }

        public void Start(params string[] files)
        {
            var stepDict = deserializer.GetStepDictionary();
            var main = deserializer.GetMain();

            var orderedSteps = new LinkedList<Step>();
            orderedSteps.AddFirst(main);
            var currentStep = orderedSteps.First;


            var flag = new NextFlag();
            var resultMap = new object();
            ConsoleManager.Setup();
            var mainView = new MainView(main);
            ConsoleManager.Content = mainView;
            var inputListeners = listenerProvider.GetListeners(mainView, currentStep, flag);

            var exit = false;
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
                        mainView.ChangeView(view);
                        inputListeners = listenerProvider.GetListeners(view, currentStep, flag);
                        flag.MoveNext = false;
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

        public void Run()
        {

        }
    }

    public class ListenerProvider
    {
        public ListenerProvider()
        {
        }

        public List<IInputListener> GetListeners(SimpleControl view, LinkedListNode<Step> currentStep, NextFlag flag)
        {
            var result = new List<IInputListener>();
            //result.Add(new QuitListener());
            //switch(view)
            //{
            //    case ChoiceView choiceView:

            //}
            return result;
        }
    }

    public class ViewProvider
    {
        public ViewProvider()
        {
        }

        public SimpleControl GetView(Step value)
        {
            switch (value)
            {
                case Choice choice:
                    return new ChoiceView(choice);
                case Series series:
                    return new SeriesView(series);
                default: throw new System.NotImplementedException();
            }
        }
    }

    public class NextFlag
    {
        public bool MoveNext { get; set; } = true;
    }
}
