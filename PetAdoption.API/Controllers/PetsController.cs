﻿namespace PetAdoption.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using PetAdoption.API.Services.Interfaces;
using PetAdoption.Shared.Dtos;

[Route("api/[controller]")]
[ApiController]
public class PetsController : ControllerBase
{
    private readonly IPetService _petService;

    public PetsController(IPetService petService)
    {
        _petService = petService;
    }

    // GET: api/pets
    [HttpGet]
    public async Task<ApiResponse<PetListDto[]>> GetAllPetsAsync() =>
        await _petService.GetAllPetsAsync();

    // GET: api/pets/new/5
    [HttpGet("new/{count:int}")]
    public async Task<ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count) =>
        await _petService.GetNewlyAddedPetsAsync(count);

    // GET: api/pets/5
    [HttpGet("{petId:int}")]
    public async Task<ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId) =>
        await _petService.GetPetDetailsAsync(petId);

    // GET: api/pets/popular/5
    [HttpGet("popular/{count:int}")]
    public async Task<ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count) =>
        await _petService.GetPopularPetsAsync(count);

    // GET: api/pets/random/5
    [HttpGet("random/{count:int}")]
    public async Task<ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count) =>
        await _petService.GetRandomPetsAsync(count);
}
