namespace PetAdoption.Mobile.Models.ViewModels
{
	[QueryProperty(nameof(IsFirstTime), nameof(IsFirstTime))]
	public partial class LoginRegisterViewModel : ObservableObject
	{
		[ObservableProperty]
		private bool _isRegistrationMode;

		[ObservableProperty]
		private LoginRegisterModel _model; 

		[ObservableProperty]
		private bool? _isFirstTime;

		[ObservableProperty]
		private bool _isBusy;

		public void Initialize()
		{
			if(IsFirstTime.HasValue && IsFirstTime.Value)
				IsRegistrationMode = true;
		}

		[RelayCommand]
		private void ToggleMode() => IsRegistrationMode = !IsRegistrationMode;

		[RelayCommand]
		private async Task SkipForNow() =>
			await Shell.Current.GoToAsync($"//{nameof(HomePage)}");

		[RelayCommand]
		private async Task Submit()
		{
			if (!Model.Validate(IsRegistrationMode))
			{
				await Toast.Make("All fields are required").Show();
				return;
			}

			IsBusy = true;

			//Make API call to login/register user
			await Task.Delay(1000);
			await SkipForNow();
			IsBusy = false;
		}
	}  
}

