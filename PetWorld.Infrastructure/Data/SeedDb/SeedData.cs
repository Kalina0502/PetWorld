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
        public RoomType BirdRoom { get; set; }
        public Room DogRooms { get; set; }
        public Room CatRooms { get; set; }
        public Room BirdRooms { get; set; }
        public Pet Dog { get; set; }
        public Pet Cat { get; set; }
        public Pet Bird { get; set; }
        public Reservation FirstReservation { get; set; }
        public Reservation SecondReservation { get; set; }

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
            SeedReservations();
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
                Email = "guest@mail.com",
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
                Name = "Male"
            };

            FemaleGender = new GenderType()
            {
                Id = 2,
                Name = "Female"
            };

            OtherGender = new GenderType()
            {
                Id = 3,
                Name = "Other"
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
                Name = "Dog"
            };

            CatSpecies = new Species()
            {
                Id = 2,
                Name = "Cat"
            };

            BirdSpecies = new Species()
            {
                Id = 3,
                Name = "Bird"
            };

            HorseSpecies = new Species()
            {
                Id = 4,
                Name = "Horse"
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
                GenderId = MaleGender.Id
            };

            Cat = new Pet()
            {
                Id = 2,
                Name = "Whiskers",
                Age = 3,
                SpeciesId = CatSpecies.Id,
                Description = "Playful cat",
                PetOwnerId = PetOwner.Id,
                GenderId = FemaleGender.Id
            };

            Bird = new Pet()
            {
                Id = 3,
                Name = "Polly",
                Age = 2,
                SpeciesId = BirdSpecies.Id,
                Description = "Talkative bird",
                PetOwnerId = PetOwner.Id,
                GenderId = FemaleGender.Id
            };
        }

        private void SeedRoomTypes()
        {

            DogRoom = new RoomType()
            {
                Id = 1,
                Name = "Dog Room"
            };

            CatRoom = new RoomType()
            {
                Id = 2,
                Name = "Cat Room"
            };

            BirdRoom = new RoomType()
            {
                Id = 3,
                Name = "Bird Room"
            };
        }

        private void SeedRooms()
        {
            DogRooms = new Room()
            {
                Id = 1,
                RoomTypeId = DogRoom.Id,
                IsAvailable = true
            };

            CatRooms = new Room()
            {
                Id = 2,
                RoomTypeId = CatRoom.Id,
                IsAvailable = true
            };

            BirdRooms = new Room()
            {
                Id = 3,
                RoomTypeId = BirdRoom.Id,
                IsAvailable = false
            };
        }

        private void SeedReservations()
        {
            FirstReservation = new Reservation()
            {
                Id = 1,
                RoomId = DogRoom.Id,
                PetId = Dog.Id,
                CheckInDate = new DateTime(2024, 3, 20),
                CheckOutDate = new DateTime(2024, 3, 25),
                IncludesFood = true,
                IncludesWalk = true
            };

            SecondReservation = new Reservation()
            {
                Id = 2,
                RoomId = CatRoom.Id,
                PetId = Cat.Id,
                CheckInDate = new DateTime(2024, 4, 1),
                CheckOutDate = new DateTime(2024, 4, 5),
                IncludesFood = false,
                IncludesWalk = true
            };
        }
    }
}