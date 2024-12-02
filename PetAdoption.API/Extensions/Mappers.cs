namespace PetAdoption.API.Extensions;
using PetAdoption.Shared;
using PetAdoption.Shared.Dtos;
using PetAdoption.Shared.Models.EntityModels;

public static class Mappers
{
	public static PetDetailDto MapToPetDetailsDto(this Pet p) =>
		new PetDetailDto
		{
			Id = p.Id,
			AdoptionStatus = p.AdoptionStatus,
			Breed = p.Breed ?? string.Empty,
			DateOfBirth = p.DateOfBirth,
			Image = $"{AppConstants.BaseApiUrl}/images/{p.Image}",
			Description = p.Description,
			Gender = p.Gender,
			Name = p.Name,
			Price = p.Price
		};
}


