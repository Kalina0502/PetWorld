using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetWorld.Infrastructure.Data.Models;
using PetWorld.Infrastructure.Data.SeedDb;

namespace PetWorld.Infarstructure.Data
{
    public class PetWorldDbContext : IdentityDbContext
    {
        public PetWorldDbContext(DbContextOptions<PetWorldDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserConfiguration());
            builder.ApplyConfiguration(new AgentConfiguration());
            builder.ApplyConfiguration(new PetOwnerConfiguration());
            builder.ApplyConfiguration(new PetConfiguration());
            builder.ApplyConfiguration(new ReservationConfiguration());
            builder.ApplyConfiguration(new RoomTypeConfiguration());
            builder.ApplyConfiguration(new GenderTypeConfiguration());
            builder.ApplyConfiguration(new RoomConfiguration());
            builder.ApplyConfiguration(new SpeciesConfiguration());



            base.OnModelCreating(builder);
        }

        public DbSet<Agent> Agents{ get; set; } = null!;
        public DbSet<AdoptionAnimal> AdoptionAnimals { get; set; } = null!;
        public DbSet<GenderType> GenderTypes { get; set; } = null!;
        public DbSet<Pet> Pets { get; set; } = null!;
        public DbSet<PetOwner> PetOwners { get; set; } = null!;
        public DbSet<Reservation> Reservations { get; set; } = null!;
        public DbSet<Room> Rooms { get; set; } = null!;
        public DbSet<Species> Species { get; set; } = null!;
        public DbSet<Groomer> Groomers { get; set; } = null!;
        public DbSet<GroomingService> GroomingServices { get; set; } = null!;
        public DbSet<ServiceType> ServiceTypes { get; set; } = null!;
        public DbSet<RoomType> RoomTypes { get; set; } = null!;
    }
}