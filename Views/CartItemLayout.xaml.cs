using MerchCount2.Models;

namespace MerchCount2.Views;

public partial class CartItemLayout : ContentView
{
	public Label TextLabel;
	public CartItemLayout(Product product)
	{
		InitializeComponent();
		TextLabel = Text ?? new Label();
		TextLabel.Text = string.Format("{0} \n {1}", product.Name, product.Saga.Name);
	}
}