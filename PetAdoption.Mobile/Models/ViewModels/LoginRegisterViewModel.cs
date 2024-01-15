using PetAdoption.Mobile.Services.Interfaces;

namespace PetAdoption.Mobile.Models.ViewModels
{
	[QueryProperty(nameof(IsFirstTime), nameof(IsFirstTime))]
	public partial class LoginRegisterViewModel : BaseViewModel
	{
        [ObservableProperty]
        private bool _isRegistrationMode;

        [ObservableProperty]
        private LoginRegisterModel _model = new();

        [ObservableProperty]
        private bool _isFirstTime;
        private readonly AuthService _authService;

        public LoginRegisterViewModel(AuthService authService)
        {
            _authService = authService;
        }

        partial void OnIsFirstTimeChanging(bool value)
        {
            if (value)
                IsRegistrationMode = true;
        }

        [RelayCommand]
		private void ToggleMode() => IsRegistrationMode = !IsRegistrationMode;

		[RelayCommand]
		private async Task SkipForNow() =>
			await GoToAsync($"//{nameof(HomePage)}");

		[RelayCommand]
		private async Task Submit()
		{
			if (!Model.Validate(IsRegistrationMode))
			{
				await ShowToastAsync("All fields are required");
				return;
			}

			IsBusy = true;

			//Make API call to login/register user
			var status = await _authService.LoginRegisterAsync(Model);
			if (status)
                await SkipForNow();
            IsBusy = false;
		}
	}  
}

