﻿using Refit;

namespace PetAdoption.Mobile.Models.ViewModels
{
    public partial class HomeViewModel: BaseViewModel
    {
        private readonly IPetsApiService _petsApiService;

        public HomeViewModel(IPetsApiService petsApiService)
        {
            _petsApiService = petsApiService;
        }

        [ObservableProperty]
        private IEnumerable<PetListDto> _newlyAddedPets = Enumerable.Empty<PetListDto>();
        
        [ObservableProperty]
        private IEnumerable<PetListDto> _popularPets = Enumerable.Empty<PetListDto>();
        
        [ObservableProperty]
        private IEnumerable<PetListDto> _randomPets = Enumerable.Empty<PetListDto>();

        [ObservableProperty]
        private string _userName = "Stranger";

        private bool _isInitialized;

        public async Task InitializeAsync()
        {
            if (_isInitialized)
                return;

            IsBusy = true;

            try
            {
                await Task.Delay(100);
                var newlyAddedPetsTask = _petsApiService.GetNewlyAddedPetsAsync(5);
                var popularPetsTask = _petsApiService.GetPopularPetsAsync(10);
                var randomPetsTask = _petsApiService.GetRandomPetsAsync(6);

                NewlyAddedPets = (await newlyAddedPetsTask).Data;
                PopularPets = (await popularPetsTask).Data;
                RandomPets = (await randomPetsTask).Data;

                _isInitialized = true;
            }
            catch (ApiException ex)
            {
                await ShowAlertAsync("Error", ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }
        
    }
}
