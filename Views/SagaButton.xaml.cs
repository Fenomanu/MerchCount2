using MerchCount2.Models;

namespace MerchCount2.Views;

public partial class SagaButton : ContentView
{
    private Saga _saga;
    public Button Button;
    public SagaButton()
	{
		InitializeComponent();
        Button = ButtonText ?? new Button();
    }

    public SagaButton(Saga g)
    {
        InitializeComponent();
        Button = ButtonText ?? new Button();
        _saga = g;
        Button.Text = _saga.Name;
    }
}