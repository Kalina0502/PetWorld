using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;
using System.Reflection.Emit;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class PetOwnerConfiguration : IEntityTypeConfiguration<PetOwner>
    {
        public void Configure(EntityTypeBuilder<PetOwner> builder)
        {
          builder
            .HasIndex(po => po.Email)
            .IsUnique()
            .HasDatabaseName("PetOwners_Email");

            var data = new SeedData();

            builder.HasData(new PetOwner[] { data.PetOwner });
        }
    }
}