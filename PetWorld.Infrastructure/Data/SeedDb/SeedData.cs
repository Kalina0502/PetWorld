using Microsoft.AspNetCore.Identity;
using PetWorld.Infrastructure.Data.Models;
namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class SeedData
    {
        public IdentityUser GuestUser { get; set; }
        public IdentityUser AgentUser { get; set; }
        public Agent Agent { get; set; }
        public PetOwner PetOwner { get; set; }
        public Species DogSpecies { get; set; }
        public Species CatSpecies { get; set; }
        public Species BirdSpecies { get; set; }
        public Species HorseSpecies { get; set; }
        public GenderType MaleGender { get; set; }
        public GenderType FemaleGender { get; set; }
        public GenderType OtherGender { get; set; }
        public RoomType DogRoom { get; set; }
        public RoomType CatRoom { get; set; }
        public Room DogRooms { get; set; }
        public Room CatRooms { get; set; }
        public Room BirdRooms { get; set; }
        public Pet Dog { get; set; }
        public Pet Cat { get; set; }
        public Pet Bird { get; set; }
        public RoomReservation FirstReservation { get; set; }
        public RoomReservation SecondReservation { get; set; }
        public AdoptionAnimal FirstAdoptionAnimal { get; set; }
        public AdoptionAnimal SecondAdoptionAnimal { get; set; }
        public Groomer FirstGroomer { get; set; }
        public Groomer SecondGroomer { get; set; }
        public Groomer ThirdGroomer { get; set; }
        public GroomingType FirstGroomingType { get; set; }
        public GroomingType SecondGroomingType { get; set; }
        public GroomingType ThirdGroomingType { get; set; }
        public GroomingReservation FirstGroomingReservation { get; set; }
        public GroomingReservation SecondGroomingReservation { get; set; }

        public SeedData()
        {
            SeedUsers();
            SeedAgent();
            SeedGenderTypes();
            SeedPetOwners();
            SeedSpecies();
            SeedPets();
            SeedRoomTypes();
            SeedRooms();
            SeedRoomReservations();
            SeedAdoptionAnimals();
            SeedGroomers();
            SeedGroomingTypes();
            SeedGroomingReservations();
        }

        private void SeedUsers()
        {
            var hasher = new PasswordHasher<IdentityUser>();

            AgentUser = new IdentityUser()
            {
                Id = "dea12856-c198-4129-b3f3-b893d8395082",
                UserName = "agent@mail.com",
                NormalizedUserName = "agent@mail.com",
                Email = "agent@mail.com",
                NormalizedEmail = "agent@mail.com"
            };

            AgentUser.PasswordHash = hasher.HashPassword(AgentUser, "agent123");

            GuestUser = new IdentityUser()
            {
                Id = "6d5800ce-d726-4fc8-83d9-d6b3ac1f591e",
                UserName = "guest@mail.com",
                NormalizedUserName = "guest@mail.com",
                Email = "guest1@mail.com",
                NormalizedEmail = "guest@mail.com"
            };

            GuestUser.PasswordHash = hasher.HashPassword(GuestUser, "guest123");
        }

        private void SeedAgent()
        {
            Agent = new Agent()
            {
                Id = 1,
                PhoneNumber = "+359888888888",
                UserId = AgentUser.Id
            };
        }

        private void SeedGenderTypes()
        {
            MaleGender = new GenderType()
            {
                Id = 1,
                Name = "Male",
                AgentId = Agent.Id
            };

            FemaleGender = new GenderType()
            {
                Id = 2,
                Name = "Female",
                AgentId = Agent.Id
            };

            OtherGender = new GenderType()
            {
                Id = 3,
                Name = "Other",
                AgentId = Agent.Id
            };
        }

        private void SeedPetOwners()
        {
            PetOwner = new PetOwner()
            {
                Id = 1,
                PetOwnerFirstName = "John",
                PetOwnerLastName = "Doe",
                Email = "john@example.com",
                PhoneNumber = "1234567890",
                Age = 30,
                GenderId = MaleGender.Id,
                UserId = GuestUser.Id
            };
        }

        private void SeedSpecies()
        {
            DogSpecies = new Species()
            {
                Id = 1,
                Name = "Dog",
            };

            CatSpecies = new Species()
            {
                Id = 2,
                Name = "Cat",
            };

            BirdSpecies = new Species()
            {
                Id = 3,
                Name = "Bird",
            };

            HorseSpecies = new Species()
            {
                Id = 4,
                Name = "Horse",
            };
        }

        private void SeedPets()
        {
            Dog = new Pet()
            {
                Id = 1,
                Name = "Buddy",
                Age = 5,
                SpeciesId = DogSpecies.Id,
                Description = "Friendly dog",
                PetOwnerId = PetOwner.Id,
                City = "Varna"
            };

            Cat = new Pet()
            {
                Id = 2,
                Name = "Whiskers",
                Age = 3,
                SpeciesId = CatSpecies.Id,
                Description = "Playful cat",
                PetOwnerId = PetOwner.Id,
                City = "Sofia"
            };

            Bird = new Pet()
            {
                Id = 3,
                Name = "Polly",
                Age = 2,
                SpeciesId = BirdSpecies.Id,
                Description = "Talkative bird",
                PetOwnerId = PetOwner.Id,
                City = "Burgas"
            };
        }

        private void SeedRoomTypes()
        {

            DogRoom = new RoomType()
            {
                Id = 1,
                Name = "Dog Room",
            };

            CatRoom = new RoomType()
            {
                Id = 2,
                Name = "Cat Room",
            };
        }

        private void SeedRooms()
        {
            DogRooms = new Room()
            {
                Id = 1,
                RoomTypeId = DogRoom.Id,
                IsAvailable = true,
                AgentId = Agent.Id
            };

            CatRooms = new Room()
            {
                Id = 2,
                RoomTypeId = CatRoom.Id,
                IsAvailable = true,
                AgentId = Agent.Id
            };
        }

        private void SeedRoomReservations()
        {
            FirstReservation = new RoomReservation()
            {
                Id = 1,
                RoomId = DogRoom.Id,
               // PetId = Dog.Id,
                CheckInDate = new DateTime(2024, 3, 20),
                CheckOutDate = new DateTime(2024, 3, 25),
                IncludesFood = true,
                IncludesWalk = true
            };

            SecondReservation = new RoomReservation()
            {
                Id = 2,
                RoomId = CatRoom.Id,
              //  PetId = Cat.Id,
                CheckInDate = new DateTime(2024, 4, 24),
                CheckOutDate = new DateTime(2024, 4, 25),
                IncludesFood = false,
                IncludesWalk = true
            };
        }

        private void SeedAdoptionAnimals()
        {
            FirstAdoptionAnimal = new AdoptionAnimal()
            {
                Id = 1,
                Name = "Fluffy",
                Age = 3,
                City = "Varna",
                Description = "Friendly dog looking for a forever home.",
                SpeciesId = DogSpecies.Id,
                ImageUrl = "https://imgs.search.brave.com/6_mK4szCUhPtgYpWPnxvThzz8t1gjuxplafy-36PLLo/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9tZWRp/YS5pc3RvY2twaG90/by5jb20vaWQvMTMw/MTgzOTExMi9waG90/by9wdXBweS13aXRo/LXRpbHRlZC1oZWFk/LWFuZC1jcm9zc2Vk/LXBhd3MtbHlpbmct/b24tc29mYS5qcGc_/cz02MTJ4NjEyJnc9/MCZrPTIwJmM9ak1x/TllGMXRPZGpIa2pP/QjZnTGdLbFc0V3I1/OGdzUWJIYnI4MnBK/Q0dpRT0",
                AgentId = Agent.Id
            };
            SecondAdoptionAnimal = new AdoptionAnimal()
            {
                Id = 2,
                Name = "Whiskers",
                Age = 2,
                City = "Sofia",
                Description = "Playful cat in need of a loving family.",
                SpeciesId = CatSpecies.Id,
                ImageUrl = "https://imgs.search.brave.com/yUi94EMJUyOlxg2hDIkB884GABSL4Cy8XSt8L314Hqg/rs:fit:860:0:0/g:ce/aHR0cHM6Ly9pbWcu/ZnJlZXBpay5jb20v/ZnJlZS1waG90by9w/b3J0cmFpdC1hZG9y/YWJsZS1kb21lc3Rp/Yy1jYXRfMjMtMjE0/OTE2NzA4OC5qcGc_/c2l6ZT02MjYmZXh0/PWpwZw",
                AgentId = Agent.Id
            };
        }
        private void SeedGroomers()
        {
            FirstGroomer = new Groomer()
            {
                Id = 1,
                Name = "Kalina Yordanova",
                Age = 23,
                Description = "Professional groomers providing high-quality grooming services.",
                AgentId = Agent.Id
            };
            SecondGroomer = new Groomer()
            {
                Id = 2,
                Name = "Constantine Nenov",
                Age = 30,
                Description = "Dedicated groomers offering personalized grooming sessions for your pets.",
                AgentId = Agent.Id
            };
            ThirdGroomer = new Groomer()
            {
                Id = 3,
                Name = "Rosica Yordanova",
                Age = 27,
                Description = "Experienced groomers who love pampering your furry friends.",
                AgentId = Agent.Id
            };
        }

        private void SeedGroomingTypes()
        {
            FirstGroomingType = new GroomingType()
            {
                Id = 1,
                Name = "Bath and Brush",
            };
            SecondGroomingType = new GroomingType()
            {
                Id = 2,
                Name = "Haircut",
            };
            ThirdGroomingType = new GroomingType()
            {
                Id = 3,
                Name = "Nail Trim",
            };
        }

        private void SeedGroomingReservations()
        {
            FirstGroomingReservation = new GroomingReservation()
            {
                Id = 1,
                PetId = 1,
                GroomerId = 1,
                GroomingTypeId = 1,
                StartTime = new DateTime(2024, 4, 24, 15, 0, 0),
                EndTime = new DateTime(2024, 4, 24, 17, 0, 0)

            };
            SecondGroomingReservation = new GroomingReservation()
            {
                Id = 2,
                PetId = 3,
                GroomerId = 2,
                GroomingTypeId = 1,
                StartTime = new DateTime(2024, 4, 28, 10, 0, 0),
                EndTime = new DateTime(2024, 4, 28, 12, 0, 0)
            };
        }
    }
}