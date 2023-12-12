﻿using Microsoft.EntityFrameworkCore;
using PetAdoption.API.Data;
using PetAdoption.API.Extensions;
using PetAdoption.API.Services.Interfaces;
using PetAdoption.Shared.Dtos;

namespace PetAdoption.API.Services
{
    public class PetService : IPetService 
    {
        private readonly PetContext _context;

        public PetService(PetContext context)
        {
            _context = context;
        }

        public async Task<ApiResponse<PetListDto[]>> GetNewlyAddedPetsAsync(int count)
        {
            var pets = await _context.Pets
                            .Select(Selectors.PetToPetListDto)
                            .OrderByDescending(p => p.Id)
                            .Take(count)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetListDto[]>> GetPopularPetsAsync(int count)
        {
            var pets = await _context.Pets
                            .OrderByDescending(p => p.Views)
                            .Take(count)
                            .Select(Selectors.PetToPetListDto)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetListDto[]>> GetRandomPetsAsync(int count)
        {
            var pets = await _context.Pets
                            .OrderByDescending(_ => Guid.NewGuid())
                            .Take(count)
                            .Select(Selectors.PetToPetListDto)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetListDto[]>> GetAllPetsAsync()
        {
            var pets = await _context.Pets
                            .OrderByDescending(p => p.Id)
                            .Select(Selectors.PetToPetListDto)
                            .ToArrayAsync();

            return ApiResponse<PetListDto[]>.Success(pets);
        }

        public async Task<ApiResponse<PetDetailDto>> GetPetDetailsAsync(int petId)
        {
            var petDetails = await _context.Pets
                                .AsTracking()
                                .FirstOrDefaultAsync(p => p.Id == petId);

            if (petDetails is not null)
            {
                petDetails.Views++;
                _context.SaveChanges();
            }

            var petDetailDto = petDetails!.MapToPetDetailsDto();

            return ApiResponse<PetDetailDto>.Success(petDetailDto);
        }
    }
}

