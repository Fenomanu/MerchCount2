
using MerchCount2.DataLayer;
using MerchCount2.Models;
using MerchCount2.Views;
using System.Diagnostics;

namespace MerchCount2;

public partial class MainMenu : ContentPage
{
	GroupDAO groupDAO;
	private int _counter = 0;
	public MainMenu(GroupDAO database)
	{
        InitializeComponent();
		groupDAO = database;
        LoadButtons();
	}
    private async void LoadButtons()
    {
        List<Group> groups = await groupDAO.GetPublicGroupsAsync();
        foreach (Group group in groups)
        {
            Debug.Print(group.Name);
            GroupButton b = new GroupButton(group);
            b.Button.Clicked += OnButtonClicked;
            BodyContent.Add(b);
        }
    }

    private async void OnButtonClicked(object? sender, EventArgs e)
	{
        if (sender is null) return;
		TopContent.Text = ((Button)sender).Text;
        Group g = new Group();
		_counter++;
        g.Name = string.Format("Grupo {0}", _counter);
        g.Price = 10;
        await groupDAO.SaveItemAsync(g);
        Debug.Print("Before Loading");
        //BodyContent.Clear();
        List<Group> groups = await groupDAO.GetPublicGroupsAsync();
        GroupButton b = new GroupButton(groups.LastOrDefault(new Group()));
        b.Button.Clicked += OnButtonClicked;
        BodyContent.Add(b);
    }

}