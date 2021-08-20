using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Input;
using ConsoleGUI.Space;
using Prompton.Steps;
using Prompton.UI.Listeners;
using Prompton.UI.Views;

namespace Prompton.UI;

public class UIProvider
{
    private readonly ViewFactory viewFactory;
    private readonly ListenerFactory listenerFactory;
    private readonly QuitListener quitListener;

    public Flag Flag { get; set; }
    public Margin ViewArea { get; set; }

    public UIProvider(ViewFactory viewFactory, ListenerFactory listenerFactory)
    {
        this.viewFactory = viewFactory;
        this.listenerFactory = listenerFactory;

        Flag = new Flag { Next = false, Quit = false };

        ViewArea = new Margin
        {
            Offset = new Offset(5, 2, 5, 2)
        };
    }

    public void Init()
    {
        ConsoleManager.Setup();
        ConsoleManager.Content = new Background
        {
            Content = new Border
            {
                Content = ViewArea
            }
        };
    }

    public StepView GetView(Step step)
    {
        return viewFactory.Create(step);
    }

    public List<IInputListener> GetListeners(StepView view)
    {
        return new List<IInputListener> { listenerFactory.Create(view, this) };
    }
}
