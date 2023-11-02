namespace PetAdoption.API.Data
{
    using Microsoft.EntityFrameworkCore;
    using PetAdoption.Shared.Enumerations;
    using PetAdoption.Shared.Models.EntityModels;
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions<PetContext> options)
            : base(options)
        { 
        }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavorites> UserFavorites { get; set; }
        public DbSet<UserAdoption> UserAdoptions { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            #if DEBUG
            optionsBuilder.LogTo(Console.WriteLine);
            #endif
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserFavorites>()
                .HasKey(uf => new { uf.UserId, uf.PetId });
            modelBuilder.Entity<Pet>()
                .HasData(InitialPetsData());
        }

        private static List<Pet> InitialPetsData()
        {
            return new List <Pet>
            {
                new Pet
                {
                    Id = 1,
                    Name = "Buddy",
                    Breed = "Dog - Golden Retriever",
                    Price = 300,
                    Description = "Buddy is a friendly and playful Golden Retriever, known for being great with kids",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU",
                    DateOfBirth = new DateTime(2021, 5, 15),
                    AdoptionStatus = AdoptionStatus.Available,
                    Gender = Gender.Male,
                    IsActive = true,
                    Views = 0
                },
                new Pet
                {
                    Id = 2,
                    Name = "Whiskers",
                    Breed = "Cat - Siamese",
                    Price = 150,
                    Description = "Whiskers is an elegant Siamese cat.",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU",
                    DateOfBirth = new DateTime(2021, 3, 21),
                    AdoptionStatus = AdoptionStatus.Available,
                    Gender = Gender.Female,
                    IsActive = true,
                    Views = 2
                },
                new Pet
                {
                    Id = 3,
                    Name = "Rocky",
                    Breed = "Dog - German Shapherd",
                    Price = 400,
                    Description = "Rocky is a friendly and playful German Shapherd, known for being great with kids",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU",
                    DateOfBirth = new DateTime(2022, 2, 28),
                    AdoptionStatus = AdoptionStatus.Available,
                    Gender = Gender.Male,
                    IsActive = true,
                    Views = 3
                },
                new Pet
                {
                    Id = 4,
                    Name = "Luna",
                    Breed = "Rabbit - Himalayan",
                    Price = 100,
                    Description = "Luna is a friendly and playful Rabbit, known for being great with kids",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU",
                    DateOfBirth = new DateTime(2021, 5, 23),
                    AdoptionStatus = AdoptionStatus.Available,
                    Gender = Gender.Female,
                    IsActive = true,
                    Views = 1
                },
                new Pet
                {
                    Id = 5,
                    Name = "Jack",
                    Breed = "Dog - Jack Russel",
                    Price = 650,
                    Description = "Jack is an elegant Jack Russel dog, known for being great with kids.",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU",
                    DateOfBirth = new DateTime(2019, 1, 22),
                    AdoptionStatus = AdoptionStatus.Adopted,
                    Gender = Gender.Female,
                    IsActive = false,
                    Views = 2
                },
                new Pet
                {
                    Id = 6,
                    Name = "Maia",
                    Breed = "Cat - Maias",
                    Price = 550,
                    Description = "Maia is a friendly and playful Maias cat, known for being great with kids",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU",
                    DateOfBirth = new DateTime(2022, 4, 12),
                    AdoptionStatus = AdoptionStatus.InProgress,
                    Gender = Gender.Male,
                    IsActive = true,
                    Views = 10
                },
                new Pet
                {
                    Id = 7,
                    Name = "Raffy",
                    Breed = "Rabbit - Himalayan",
                    Price = 150,
                    Description = "Raffy is a friendly and playful Rabbit, known for being great with kids",
                    Image = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcTTtOTQTsPs2GqkuwjqqcmoNjMNmcTdyggqbQ&usqp=CAU",
                    DateOfBirth = new DateTime(2020, 8, 11),
                    AdoptionStatus = AdoptionStatus.Available,
                    Gender = Gender.Male,
                    IsActive = false,
                    Views = 5
                }
            };
        }
    }
}
