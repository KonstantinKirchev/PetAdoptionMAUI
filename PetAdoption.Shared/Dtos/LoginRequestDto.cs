namespace PetAdoption.Shared.Dtos
{
    using System.ComponentModel.DataAnnotations;
    public class LoginRequestDto
    {
        [Required, EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
