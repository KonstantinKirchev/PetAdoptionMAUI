using Refit;

namespace PetAdoption.Mobile.Services.Interfaces
{
    [Headers("Authorization: Bearer")]
    public interface IUserPetApiService
    {
        [Post("/api/user/adopt/{petId}")]
        Task<ApiResponse> AdoptPetAsync(int userId, int petId);

        [Get("/api/user/adoptions")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserAdoptionsAsync(int userId);

        [Get("/api/user/favorites")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserFavoritesAsync(int userId);

        [Post("/api/user/favorites/{petId}")]
        Task<ApiResponse> ToggleFavoritesAsync(int userId, int petId);
    }
}
