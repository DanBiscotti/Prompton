using ConsoleGUI;
using ConsoleGUI.Controls;
using ConsoleGUI.Data;
using ConsoleGUI.Space;
using ConsoleGUI.UserDefined;
using Prompton.Steps;

namespace Prompton.UI.Views;

public class MainView : SimpleControl
{
    private MainStep main;

    public MainView(MainStep main)
    {
        this.main = main; 
		var textBox1 = new TextBox { Text = "Hello world" };
		var textBox2 = new TextBox { Text = "Test" };
		var textBlock = new TextBlock();

		var button = new Button { Content = new Margin { Offset = new Offset(4, 1, 4, 1), Content = new TextBlock { Text = "Button" } } };

		Content = new Background
		{
			Color = new Color(100, 0, 0),
			Content = new Margin
			{
				Offset = new Offset(5, 2, 5, 2),
				Content = new VerticalStackPanel
				{
					Children = new IControl[]
						{
							textBlock,
							new HorizontalSeparator(),
							new TextBlock { Text = "Simple text box" },
							new Background{
								Color = Color.Black,
								Content = textBox1
							},
							new HorizontalSeparator(),
							new TextBlock { Text = "Wrapped text box" },
							new Boundary
							{
								Width = 10,
								Content = new Background
								{
									Color = new Color(0, 100, 0),
									Content = new WrapPanel { Content = new Boundary{ MinWidth = 10, Content = textBox2 } }
								}
							},
							new HorizontalSeparator(),
							new Boundary
							{
								Height = 1,
								Content = new HorizontalStackPanel
								{
									Children = new IControl[]
									{
										new TextBlock {Text = "Check box: "},
										new CheckBox {
											TrueCharacter = new Character('Y', new Color(0, 255, 0)),
											FalseCharacter = new Character('N', new Color(255, 0, 0))
										}
									}
								}
							},
							new HorizontalSeparator(),
							new Box { Content = button }
						}
				}
			}
		};
	}

    public void ChangeView(SimpleControl view)
    {
        Content = view;
    }
}
