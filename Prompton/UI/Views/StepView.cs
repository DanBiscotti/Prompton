using ConsoleGUI.Controls;
using ConsoleGUI.UserDefined;
using Prompton.Steps;

namespace Prompton.UI.Views
{
    public class StepView : SimpleControl
    {
        private Step step;

        protected StepView(Step step)
        {
            this.step = step;
        }

        protected Box BuildPrompt()
        {
            return new Box
            {
                Content = new TextBlock
                {
                    Text = step.Prompt
                }
            };
        }


    }
}
