using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PetWorld.Infrastructure.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PetWorld.Infrastructure.Data.SeedDb
{
    internal class GroomingTypeConfiguration : IEntityTypeConfiguration<GroomingType>
    {
        public void Configure(EntityTypeBuilder<GroomingType> builder)
        {
            builder
           .HasOne(gt => gt.Agent)
           .WithMany()
           .HasForeignKey(gt => gt.AgentId)
           .OnDelete(DeleteBehavior.Restrict);

            var data = new SeedData();

            builder.HasData(new GroomingType[] { data.FirstGroomingType, data.SecondGroomingType, data.ThirdGroomingType });
        }
    }
}
