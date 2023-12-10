using PetAdoption.Shared.Dtos;

namespace PetAdoption.API.Services.Interfaces
{
	public interface IAuthService
	{
        Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);

        Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
    }
}

