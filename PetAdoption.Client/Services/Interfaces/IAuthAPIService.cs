﻿using PetAdoption.Shared.Dtos;
using Refit;

namespace PetAdoption.Client.Services.Interfaces
{
    public interface IAuthApiService
    {
        [Post("/api/auth/login")]
        Task<Shared.Dtos.ApiResponse<AuthResponseDto>> LoginAsync(LoginRequestDto dto);

        [Post("/api/auth/register")]
        Task<Shared.Dtos.ApiResponse<AuthResponseDto>> RegisterAsync(RegisterRequestDto dto);
    }
}
