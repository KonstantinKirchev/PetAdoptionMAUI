using Microsoft.Extensions.Logging;
using CommunityToolkit.Maui;
using Refit;
using PetAdoption.Shared;
using PetAdoption.Mobile.Services.Interfaces;

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
				.AddTransient<LoginRegisterPage>()
				.AddTransient<AuthService>()
				.AddSingleton<CommonService>()
                .AddSingleton<HomeViewModel>()
                .AddSingleton<HomePage>();
	}

	static void ConfigureRefit(IServiceCollection services)
	{
		services.AddRefitClient<IAuthApiService>()
			.ConfigureHttpClient(SetHttpClient);

        services.AddRefitClient<IPetsApiService>()
            .ConfigureHttpClient(SetHttpClient);

		services.AddRefitClient<IUserPetApiService>(serviceProvider =>
			{
				var commonService = serviceProvider.GetRequiredService<CommonService>();

				return new RefitSettings()
				{
					AuthorizationHeaderValueGetter = (_, __) => Task.FromResult(commonService.Token ?? string.Empty)
				};
			})
			.ConfigureHttpClient(SetHttpClient);
    }

	static void SetHttpClient(HttpClient httpClient) => httpClient.BaseAddress = new Uri(AppConstants.BaseApiUrl);
}

