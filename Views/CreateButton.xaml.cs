using MerchCount2.Models;

namespace MerchCount2.Views;

public partial class CreateButton : ContentView
{
    public Button Button;
    public CreateButton()
	{
		InitializeComponent();
        Button = ButtonText ?? new Button();
        ButtonText.ImageSource = "";
    }
}