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
    public class AppointmentsConfgurations : IEntityTypeConfiguration<Appointments>
    {
        public void Configure(EntityTypeBuilder<Appointments> builder)
        {
            builder.HasKey(a => a.Id);

            
            builder.Property(a => a.AppointmentDate)
                   .IsRequired();

           
            builder.Property(a => a.Status)
                   .IsRequired()
                   .HasMaxLength(50);

           
            builder.Property(a => a.Notes)
                   .HasMaxLength(500);

            
            builder.Property(a => a.CreatedAt)
                   .IsRequired();

           builder.Property(a => a.PatientName)
            .HasMaxLength(100)
            .IsRequired(false);



        }
    }
 
}
