using LinkUp.ViewModel;
using Microsoft.Extensions.Logging;

namespace LinkUp
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            string root = new Globals().ROOT_DIRECTORY;
            Directory.CreateDirectory(root + Globals.USER_DIRECTORY);
            Directory.CreateDirectory(root + Globals.GROUP_DIRECTORY);


            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });


            // Singleton global creates one copy
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddSingleton<MainViewModel>();

            // Transient created and destroyed everytime
            builder.Services.AddTransient<DetailPage>();
            builder.Services.AddTransient<DetailViewModel>();

#if DEBUG
            builder.Logging.AddDebug();
            #endif

            return builder.Build();
        }
    }
}