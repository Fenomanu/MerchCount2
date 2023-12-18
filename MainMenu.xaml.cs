
using MerchCount2.DataLayer;
using MerchCount2.Models;
using MerchCount2.Views;
using System.ComponentModel;
using System.Diagnostics;

namespace MerchCount2;

public partial class MainMenu : ContentPage
{
    GroupDAO groupDAO;
	private int _counter = 0;
    //public MainMenu()
    //{
    //    InitializeComponent();
    //}
	public MainMenu(GroupDAO database)
	{
        InitializeComponent();
        groupDAO = database;
        LoadButtons();
        CartButton.Button.Clicked += OnOpenCartClicked;
        ((GroupButton)FirstButton).Button.Clicked += OnButtonClicked;
    }
    private async void LoadButtons()
    {
        List<Group> groups = await groupDAO.GetGroupsAsync();

        //Pack Button
        GroupButton adminButton = new GroupButton(groups.Find(item => item.ID == 1)?? new Group());
        adminButton.Button.Clicked += OnLoadGroupPage;
        BodyContent.Add(adminButton);

        foreach (Group group in groups.Where(item => !item.IsAdminOnly))
        {
            Debug.Print(group.Name);
            GroupButton groupButton = new GroupButton(group);
            groupButton.Button.Clicked += OnLoadGroupPage;
            BodyContent.Add(groupButton);
        }

        //Stock Button
        adminButton = new GroupButton(groups.Find(item => item.ID == 2) ?? new Group());
        adminButton.Button.Clicked += OnLoadGroupPage;
        BodyContent.Add(adminButton);

        //Add Items Button

    }

    private async void OnButtonClicked(object? sender, EventArgs e)
	{
        if (sender is null) return;
        Group g = new Group();
		_counter++;
        g.Name = string.Format("Grupo {0}", _counter);
        g.Price = 10;
        await groupDAO.SaveGroupAsync(g);
        Debug.Print("Before Loading");
        //BodyContent.Clear();
        List<Group> groups = await groupDAO.GetPublicGroupsAsync();
        GroupButton b = new GroupButton(groups.LastOrDefault(new Group()));
        b.Button.Clicked += OnLoadGroupPage;
        BodyContent.Add(b);
    }

    private async void OnLoadGroupPage(object? sender, EventArgs e)
    {
        if (sender is null) return;
        Group g = new Group();
        _counter++;
        g.Name = string.Format("Grupo {0}", _counter);
        g.Price = 10;
        await groupDAO.SaveGroupAsync(g);
        Debug.Print("Before Loading");
        //BodyContent.Clear();
        List<Group> groups = await groupDAO.GetPublicGroupsAsync();
        GroupButton b = new GroupButton(groups.LastOrDefault(new Group()));
        b.Button.Clicked += OnLoadGroupPage;
        BodyContent.Add(b);
    }

    private async void OnOpenCartClicked(object? sender, EventArgs e)
    {
        BlackBack.IsVisible = true;
        SideDrawer.IsVisible = true;
        await SideDrawer.TranslateTo(0, 0, 100, Easing.SinIn);
        await BlackBack.TranslateTo(-400,0,100, Easing.SinIn);
    }

    private void AddButtonToDrawer(string buttonText)
    {
        var button = new Button { Text = buttonText };
        DynamicButtonContainer.Children.Add(button);

        // Puedes a�adir eventos Click u otros manejadores aqu�
    }

    private async void OnOutsideCartTapped(object? sender, EventArgs e)
    {
        // Animaci�n para deslizar el desplegable hacia fuera de la pantalla
        await BlackBack.TranslateTo(0, 0, 0);
        await SideDrawer.TranslateTo(400, 0, 0);
        BlackBack.IsVisible = false;
        SideDrawer.IsVisible = false;
    }
}