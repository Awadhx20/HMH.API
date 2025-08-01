using HMH.core.Entites;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HMH.Infrastructure.Data.Config
{
    internal class ClinicsConfigurations : IEntityTypeConfiguration<Clinics>
    {
        public void Configure(EntityTypeBuilder<Clinics> builder)
        {
           
           
            
            builder.HasKey(c => c.Id);

            
            builder.Property(c => c.Name)
                   .IsRequired()
                   .HasMaxLength(256);


            builder.Property(c => c.Image)
                   .IsRequired();
                  

           
        
            builder.HasData(
                new Clinics { Id = 1, Name = "Test", Image = "testImage" });
        }
                

        }
    }

