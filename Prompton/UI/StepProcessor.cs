using Prompton.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Prompton.UI
{
    public class StepProcessor
    {
        public LinkedListNode<Step> ProcessStep(LinkedList<Step> steps, LinkedListNode<Step> current)
        {
            var b = new Dictionary<Type, Func<LinkedListNode<Step>>>()
            {
                { typeof(Series), () => {
                    foreach(Step s in ((Series)current.Value).Steps.Reverse()) {
                        steps.AddAfter(current, s);
                    }
                    return current.Next; }
                },
            };
        }
    }
}
