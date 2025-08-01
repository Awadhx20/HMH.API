using HMH.core.Entites.Dectors;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Data.Config
{
    public class RatingsConfigrations : IEntityTypeConfiguration<Ratings>
    {
        public void Configure(EntityTypeBuilder<Ratings> builder)
        {
            builder.HasKey(r => r.Id);

           
            builder.Property(r => r.Stars)
                   .IsRequired();

           
            builder.Property(r => r.Comment)
                   .HasMaxLength(500);


            builder.Property(r => r.RatedAt);// not requird now , mybe for future :)
                   

            
           
        }
    }
}
