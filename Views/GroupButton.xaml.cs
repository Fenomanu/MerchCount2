using MerchCount2.Models;

namespace MerchCount2.Views;

public partial class GroupButton : ContentView
{
	Group group;
	public Button Button;
	public GroupButton()
	{
		InitializeComponent();
        Button = ButtonText ?? new Button();
    }
	public GroupButton(Group g)
	{
		InitializeComponent();
        Button = ButtonText;
		group = g;
		ButtonText.Text = group.Name;
	}
}