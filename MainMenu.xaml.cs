
using MerchCount2.DataLayer;
using MerchCount2.Models;
using MerchCount2.Views;
using System.ComponentModel;
using System.Diagnostics;

namespace MerchCount2;

public partial class MainMenu : ContentPage
{
    GroupDAO GroupSingleton;
    ProductDAO ProductSingeton;
	private int _counter = 0;

    // Try to make button appearance async
	public MainMenu(GroupDAO database)//, ProductDAO products)
	{
        // Initialize component and store singletons
        InitializeComponent();
        GroupSingleton = database;
        //ProductSingeton = products;
        
        // Load Groups Buttons
        LoadGroupsButtons();

        // Load Hot Products
        //LoadProductsButtons();

        // Event handlers for default buttons
        CartButton.Button.Clicked += OnOpenCartClicked;
        FirstProd.Button.Clicked += AddProductToCart;
        FirstButton.Button.Clicked += OnButtonClicked;
    }
    private async void LoadGroupsButtons()
    {
        List<Group> groups = await GroupSingleton.GetGroupsAsync();
        Debug.Print(string.Format("-- Loaded {0} groups from {1}",groups.Count, GroupSingleton.DataPath));

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
        CreateButton createButton = new CreateButton();
        createButton.Button.Clicked += OnLoadGroupPage;
        BodyContent.Add(createButton);
    }

    private async void LoadProductsButtons()
    {
        List<Product> hotProducts = await ProductSingeton.GetHotProductsAsync();
        foreach(Product p in hotProducts)
        {
            HotProducts.Add(new ProductButton(p));
        }
    }

    private async void OnButtonClicked(object? sender, EventArgs e)
	{
        if (sender is null) return;
        Group g = new Group();
		_counter++;
        g.Name = string.Format("Grupo {0}", _counter);
        g.Price = 10;
        await GroupSingleton.SaveGroupAsync(g);
        Debug.Print("Before Loading");
        //BodyContent.Clear();
        List<Group> groups = await GroupSingleton.GetPublicGroupsAsync();
        GroupButton b = new GroupButton(groups.LastOrDefault(new Group()));
        b.Button.Clicked += OnLoadGroupPage;
        BodyContent.Children.Add(b);
    }

    private async void OnLoadGroupPage(object? sender, EventArgs e)
    {
        if (sender is null) return;

    }

    private async void OnOpenCartClicked(object? sender, EventArgs e)
    {
        BlackBack.IsVisible = true;
        SideDrawer.IsVisible = true;
        await SideDrawer.TranslateTo(0, 0, 125, Easing.SinIn);
        await BlackBack.TranslateTo(-400,0,125, Easing.SinIn);
    }

    private void AddProductToCart(object? sender, EventArgs e)
    {
        var item = new CartItemLayout(((ProductButton)(sender??new ProductButton())).GetProduct());
        CartItems.Add(item);

    }


    private async void OnOutsideCartTapped(object? sender, EventArgs e)
    {
        // Animación para deslizar el desplegable hacia fuera de la pantalla
        await BlackBack.TranslateTo(0, 0, 0);
        await SideDrawer.TranslateTo(400, 0, 0);
        BlackBack.IsVisible = false;
        SideDrawer.IsVisible = false;
    }
}