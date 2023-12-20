using MerchCount2.Models;

namespace MerchCount2.Views;

public partial class CreateButton : ContentView
{
    public CreateButton Button;
    public event EventHandler Clicked;


    public CreateButton()
	{
        Button = this;
		InitializeComponent();
        var tapGesture = new TapGestureRecognizer();
        tapGesture.Tapped += (s, e) => {
            // Invoca el evento Clicked
            Clicked?.Invoke(this, EventArgs.Empty);
        };
        this.GestureRecognizers.Add(tapGesture);
    }
}