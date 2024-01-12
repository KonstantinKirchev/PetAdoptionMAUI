using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Refit;
using PetAdoption.Shared;

namespace PetAdoption.Mobile;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("Ubuntu-Regular.ttf", "UbuntuRegular");
				fonts.AddFont("Ubuntu-Bold.ttf", "UbuntuBold");
			})
			.UseMauiCommunityToolkit();

#if DEBUG
		builder.Logging.AddDebug();
#endif
		RegisterAppDependencies(builder.Services);
		ConfigureRefit(builder.Services);


        return builder.Build();
	}

	static void RegisterAppDependencies(IServiceCollection services)
	{
		services.AddTransient<LoginRegisterViewModel>()
				.AddTransient<LoginRegisterPage>();
	}

	static void ConfigureRefit(IServiceCollection services)
	{
		services.AddRefitClient<IAuthApiService>()
			.ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri(AppConstants.BaseApiUrl));
	}
}

