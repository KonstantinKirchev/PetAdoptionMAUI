using PetAdoption.Mobile.Services.Interfaces;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.Mobile.Services
{
    public class AuthService
    {
        private readonly CommonService _commonService;
        private readonly IAuthApiService _authApiService;

        public AuthService(CommonService commonService, IAuthApiService authApiService) 
        {
            _commonService = commonService;
            _authApiService = authApiService;
        }

        public async Task<bool> LoginRegisterAsync(LoginRegisterModel model)
        {
            ApiResponse<AuthResponseDto> apiResponse = null;
            
            try
            {
                if (model.IsNewUser)
                {
                    apiResponse = await _authApiService.RegisterAsync(new RegisterRequestDto
                    {
                        Name = model.Name,
                        Email = model.Email,
                        Password = model.Password
                    });
                }
                else
                {
                    apiResponse = await _authApiService.LoginAsync(new LoginRequestDto
                    {
                        Email = model.Email,
                        Password = model.Password
                    });
                }
            }
            catch (Refit.ApiException ex)
            {
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
                return false;
            }

            if (!apiResponse.IsSuccess)
            {
                await App.Current.MainPage.DisplayAlert("Error", apiResponse.Message, "Ok");
                return false;
            }

            var user = new LoggedInUser(apiResponse.Data.UserId, apiResponse.Data.Name, apiResponse.Data.Token);
            SetUser(user);

            _commonService.SetToken(apiResponse.Data.Token);

            return true;
        }

        private void SetUser(LoggedInUser user) =>
            Preferences.Default.Set(UIConstants.UserInfo, user.ToJson());

        public async Task Logout()
        {
            _commonService.SetToken(null);
            Preferences.Default.Remove(UIConstants.UserInfo);
        }

        public LoggedInUser GetUser()
        {
            var userJson = Preferences.Default.Get(UIConstants.UserInfo, string.Empty);
            return LoggedInUser.LoadFromJson(userJson);
        }

        public bool IsLoggedIn => Preferences.Default.ContainsKey(UIConstants.UserInfo);
    }
}
