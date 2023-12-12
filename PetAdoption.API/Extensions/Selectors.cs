using System.Linq.Expressions;
using PetAdoption.Shared.Dtos;
using PetAdoption.Shared.Models.EntityModels;

namespace PetAdoption.API.Extensions
{
	public static class Selectors
	{
		public static Expression<Func<Pet, PetListDto>> PetToPetListDto =>
			p => new PetListDto
			{
				Id = p.Id,
                Breed = p.Breed,
				Image = p.Image,
				Name = p.Name,
				Price = p.Price
			};
	}
}

