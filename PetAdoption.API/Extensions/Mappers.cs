using PetAdoption.Shared;
using PetAdoption.Shared.Dtos;
using PetAdoption.Shared.Models.EntityModels;

namespace PetAdoption.API.Extensions
{
	public static class Mappers
	{
		public static PetDetailDto MapToPetDetailsDto(this Pet p) =>
			new PetDetailDto
			{
                Id = p.Id,
                AdoptionStatus = p.AdoptionStatus,
				Breed = p.Breed,
				DateOfBirth = p.DateOfBirth,
				Image = $"{AppConstants.BaseApiUrl}/images/{p.Image}",
				Description = p.Description,
				Gender = p.Gender,
				Name = p.Name,
				Price = p.Price
			};
	}
}

