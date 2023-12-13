namespace MerchCount2;

public partial class MainMenu : ContentPage
{
	public MainMenu()
	{
		InitializeComponent();
		for (int i = 0; i < 10; i++)
		{
            BodyContent.Add(new GroupButton());
		}
	}

    private void OnButtonClicked(object sender, EventArgs e)
	{
		TopContent.Text = ((Button)sender).Text;
	}
}