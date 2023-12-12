using PetAdoption.Shared.Dtos;

namespace PetAdoption.API.Services.Interfaces
{
    public interface IPetService 
    {
        Task<ApiResponse<PetListDto[]>> GetAllPetsAsync();
        Task<ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count);
        Task<ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId);
        Task<ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count);
        Task<ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count);
    }
}