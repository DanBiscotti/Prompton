using ConsoleGUI;
using System.Threading;
using Testing;

ConsoleManager.Setup();
ConsoleManager.Content = new TestView(1);
var flag = new TestFlag();
var listener = new TestListener(2, flag);
while(!flag.Exit)
{
    Thread.Sleep(10);
    ConsoleManager.ReadInput(new[] { listener });
}