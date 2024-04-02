using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetWorld.Infrastructure.Data.Models;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class GroomerConfiguration : IEntityTypeConfiguration<Groomer>
    {
        public void Configure(EntityTypeBuilder<Groomer> builder)
        {
               builder
               .HasOne(gr => gr.Agent)
               .WithMany() 
               .HasForeignKey(gr => gr.AgentId)
               .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new Groomer[] { data.FirstGroomer, data.SecondGroomer, data.ThirdGroomer });
        }
    }
}
