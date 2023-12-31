namespace PetAdoption.Mobile.Pages;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();

		Preferences.Default.Set(UIConstants.OnboardingShown, string.Empty);
	}

	private async void Explore_Button_Clicked(object sender, EventArgs e)
	{
		await Shell.Current.GoToAsync($"//{nameof(LoginRegisterPage)}");
	}
}