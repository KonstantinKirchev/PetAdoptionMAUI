﻿namespace PetAdoption.Shared.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class UserAdoption
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public int UserId { get; set; }
    public int PetId { get; set; }
    public DateTime AdoptedOn { get; set; }
    public virtual User? User { get; set; }
    public virtual Pet? Pet { get; set; }
}


