using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Mobile.Services.Interfaces
{
    [Headers("Authorization: Bearer")]
    public interface IUserPetApiService
    {
        [Post("/api/user/adopt/{petId:int}")]
        Task<ApiResponse> AdoptPetAsync(int userId, int petId);

        [Get("/api/user/adoptions")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserAdoptionsAsync(int userId);

        [Get("/api/user/favorites")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetUserFavoritesAsync(int userId);

        [Post("/api/user/favorites/{petId:int}")]
        Task<ApiResponse> ToggleFavoritesAsync(int userId, int petId);
    }
}
