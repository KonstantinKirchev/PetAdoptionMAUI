using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;

namespace PetAdoption.Client
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder.UseMauiApp<App>().ConfigureFonts(fonts =>
            {
                fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
                fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
            }).UseMauiCommunityToolkit();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            return builder.Build();
        }
    }
}