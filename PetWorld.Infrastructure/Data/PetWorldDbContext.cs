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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.Room)
                .WithMany()
                .HasForeignKey(r => r.RoomId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.Gender)
                .WithMany()
                .HasForeignKey(p => p.GenderId)
                .OnDelete(DeleteBehavior.Restrict);
        }


    }
}