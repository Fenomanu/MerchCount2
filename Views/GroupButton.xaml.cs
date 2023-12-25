using MerchCount2.Models;

namespace MerchCount2.Views;

public partial class GroupButton : ContentView
{
	private Group _group;
	public Button Button;
	public GroupButton()
	{
		InitializeComponent();
		SetParameters(new Group { Name="Group"});
    }
	public GroupButton(Group g)
	{
		InitializeComponent();
		SetParameters(g);
	}
	private void SetParameters(Group group)
	{
        Button = ButtonText ?? new Button();
        _group = group;
        Button.Text = _group.Name;
		//Button.Pressed += ButtonPressed;
		//Button.Released += ButtonReleased;
    }
	//public void ButtonPressed(object? sender, EventArgs e)
	//{
 //       var animacion = new Animation();
 //       animacion.Add(0, 1, new Animation(v => Button.TranslationY = v, 0, 5));
 //       animacion.Add(0, 1, new Animation(v => ModifyShadowOffset(1, v), 5, 0));

 //       animacion.Commit(this, "PresionarBoton", 16, 100, Easing.Linear);
 //   }
	//private void ModifyShadowOffset(int axis, double value)
	//{
	//	switch (axis)
	//	{
	//		case 0:
	//			ButtonShadow.Offset = new Point(value, ButtonShadow.Offset.Y);
	//			break;
	//		case 1:
	//			ButtonShadow.Offset = new Point(ButtonShadow.Offset.X, value);
	//			break;
	//	}
	//}
	//public void ButtonReleased(object? sender, EventArgs e)
 //   {
 //       var animacion = new Animation();
 //       animacion.Add(0, 1, new Animation(v => Button.TranslationY = v, 5, 0));
 //       animacion.Add(0, 1, new Animation(v => ModifyShadowOffset(1, v), 0, 5));

 //       animacion.Commit(this, "SoltarBoton", 16, 100, Easing.Linear);
 //   }
}