﻿using MerchCount2.DataLayer;
using Microsoft.Extensions.Logging;

namespace MerchCount2
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    //fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    //fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                    fonts.AddFont("Lemon-Tea.ttf", "LemonTea");
                });

            

            builder.Services.AddSingleton<ProductDAO>();
            builder.Services.AddSingleton<GroupDAO>();
            builder.Services.AddTransient<MainMenu>();

#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
