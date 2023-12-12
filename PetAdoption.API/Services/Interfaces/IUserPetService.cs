using PetAdoption.Shared.Dtos;

namespace PetAdoption.API.Services.Interfaces
{
    public interface IUserPetService
    {
        Task<ApiResponse> AdoptPetAsync(int userId, int petId);
        Task<ApiResponse<PetListDto[]>> GetUserAdoptionsAsync(int userId);
        Task<ApiResponse<PetListDto[]>> GetUserFavoritesAsync(int userId);
        Task<ApiResponse> ToggleFavoritesAsync(int userId, int petId);
    }
}