namespace PetAdoption.Shared.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class User
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(30)]
    public required string Name { get; set; }

    [Required, MaxLength(100)]
    public required string Email { get; set; }

    //[Required, MaxLength(10)]
    //public string Salt { get; set; }

    //[Required, MaxLength(80)]
    //public string Hash { get; set; }

    [Required, MaxLength(10)]
    public required string Password { get; set; }

}

