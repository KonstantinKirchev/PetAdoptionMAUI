namespace PetAdoption.Shared.Dtos
{
    using System.ComponentModel.DataAnnotations;
    public class RegisterRequestDto : LoginRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
