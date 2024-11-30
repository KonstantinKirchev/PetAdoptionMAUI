namespace PetAdoption.Shared.Dtos;

public class PetListDto
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Image { get; set; }
    public double Price { get; set; }
    public required string Breed { get; set; }

}

