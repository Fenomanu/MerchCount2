namespace MerchCount2
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }
        protected override void OnStart()
        {
            base.OnStart();

            // Inicializacion de aplicacion
            if (!Directory.Exists(Constants.ImagesPath))
            {
                Directory.CreateDirectory(Constants.ImagesPath);
            }
        }

        protected override void OnResume()
        {
            base.OnResume();
        }

        protected override void OnSleep()
        {
            base.OnSleep();
        }
    }
}