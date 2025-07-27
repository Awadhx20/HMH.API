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
    public class DoctorConfigrations : IEntityTypeConfiguration<Doctor>
    {
        public void Configure(EntityTypeBuilder<Doctor> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(x => x.Name)
                   .IsRequired()
                   .HasMaxLength(50);

           
            builder.Property(x => x.Specialty)
                   .HasMaxLength(80);

         
            builder.Property(x => x.Description)
                   .HasMaxLength(300);

          
            //builder.Property(x => x.Image)
            //       .HasMaxLength(200);

            builder.Property(x => x.Experience)
                   .IsRequired();

            builder.HasOne(x => x.Clinics)
                   .WithMany(c => c.Doctors)
                   .HasForeignKey(x => x.ClinicsId)
                   .OnDelete(DeleteBehavior.Cascade);

            

            
            builder.HasMany(x => x.Ratings)
                   .WithOne(x => x.Doctor)
                   .HasForeignKey(x => x.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);

           
            builder.HasMany(x => x.DoctorSchedules)
                   .WithOne(x => x.Doctor)
                   .HasForeignKey(x => x.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);

            
            builder.HasMany(x => x.Appointments)
                   .WithOne(x => x.Doctor)
                   .HasForeignKey(x => x.DoctorId)
                   .OnDelete(DeleteBehavior.Cascade);

            builder.HasData(
                new Doctor
                {
                    Id = 1,
                    Name = "test",
                    Description = "test",
                    Specialty="test",
                    Experience=10,
                    Image = "test",
                    ClinicsId = 1,
                    
                });
        }
    }
}
