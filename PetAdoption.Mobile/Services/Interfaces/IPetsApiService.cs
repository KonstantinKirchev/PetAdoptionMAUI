using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Mobile.Services.Interfaces
{
    public interface IPetsApiService
    {
        [Get("/api/pets")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetAllPetsAsync();

        [Get("/api/pets/new/{count:int}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count);

        [Get("/api/pets/{petId:int}")]
        Task<Shared.Dtos.ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId);

        [Get("/api/pets/popular/{count:int}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count);

        [Get("/api/pets/random/{count:int}")]
        Task<Shared.Dtos.ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count);
    }
}
