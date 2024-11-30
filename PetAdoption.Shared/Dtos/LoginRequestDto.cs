namespace PetAdoption.Shared.Dtos;
using System.ComponentModel.DataAnnotations;

public class LoginRequestDto
{
    [Required, EmailAddress]
    public required string Email { get; set; }

    [Required]
    public required string Password { get; set; }
}

