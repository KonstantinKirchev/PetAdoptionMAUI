﻿namespace PetAdoption.Shared.Models.EntityModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PetAdoption.Shared.Enumerations;

public class Pet
{
    [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }

    [Required, MaxLength(25)]
    public required string Name { get; set; }

    [Required, MaxLength(180)]
    public required string Image { get; set; }

    [MaxLength(50)]
    public string? Breed { get; set; }

    [Required]
    public Gender Gender { get; set; }

    [Required, Range(0, double.MaxValue)]
    public double Price { get; set; }

    public DateTime DateOfBirth { get; set; }

    [Required, MaxLength(250)]
    public required string Description { get; set; }

    public int Views { get; set; }

    public AdoptionStatus AdoptionStatus { get; set; } = AdoptionStatus.Available;

    public bool IsActive { get; set; } = true;
}
