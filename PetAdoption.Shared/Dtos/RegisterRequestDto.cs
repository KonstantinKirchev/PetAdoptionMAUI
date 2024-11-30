namespace PetAdoption.Shared.Dtos
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterRequestDto : LoginRequestDto
    {
        [Required]
        public required string Name { get; set; }
    }
}
