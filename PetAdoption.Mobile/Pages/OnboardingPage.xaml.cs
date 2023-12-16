namespace PetAdoption.Mobile.Pages;

public partial class OnboardingPage : ContentPage
{
	public OnboardingPage()
	{
		InitializeComponent();

		Preferences.Default.Set(UIConstants.OnboardingShown, string.Empty);
	}
}