namespace PetAdoption.API.Services.Interfaces;
using PetAdoption.Shared.Dtos;

public interface IAuthService
{
    Task<ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);

    Task<ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
}


