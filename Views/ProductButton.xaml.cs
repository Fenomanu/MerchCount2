using MerchCount2.Models;
using System.Diagnostics;

namespace MerchCount2.Views;

public partial class ProductButton : ContentView
{
	public ImageButton Button;
	private Product _product;
	public ProductButton()
	{
		InitializeComponent();
		_product = new Product();
		Button = ButtonText??new ImageButton();
	}
	public ProductButton(Product p)
	{
		InitializeComponent();
		_product = p;
		Button = ButtonText??new ImageButton();
		Button.Source = "add.png";
		//Button.Source = _product.FullImagePath;
		Debug.Print(Button.Source.ToString());
	}

	public Product GetProduct()
	{
		return _product;
	}
}