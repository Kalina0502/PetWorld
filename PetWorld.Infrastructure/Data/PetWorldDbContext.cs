using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infarstructure.Data
{
    public class PetWorldDbContext : IdentityDbContext
    {
        public PetWorldDbContext(DbContextOptions<PetWorldDbContext> options)
            : base(options)
        {

        }

        public DbSet<AdoptionAnimal> AdoptionAnimals { get; set; }
        public DbSet<GenderType> GenderTypes { get; set; }
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetOwner> PetOwners { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Species> Species { get; set; }
        public DbSet<Groomer> Groomers { get; set; }
        public DbSet<GroomingService> GroomingServices { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}