namespace MerchCount2.Views;

public partial class ProductButton : ContentView
{
	public Button Button;
	public ProductButton()
	{
		InitializeComponent();
		Button = ButtonText??new Button();
	}
}