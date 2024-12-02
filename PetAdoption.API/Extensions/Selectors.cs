namespace PetAdoption.API.Extensions;
using System.Linq.Expressions;
using PetAdoption.Shared;
using PetAdoption.Shared.Dtos;
using PetAdoption.Shared.Models.EntityModels;

public static class Selectors
{
	public static Expression<Func<Pet, PetListDto>> PetToPetListDto =>
		p => new PetListDto
		{
			Id = p.Id,
			Breed = p.Breed ?? string.Empty,
			Image = $"{AppConstants.BaseApiUrl}/images/pets/{p.Image}",
			Name = p.Name,
			Price = p.Price
		};
}


