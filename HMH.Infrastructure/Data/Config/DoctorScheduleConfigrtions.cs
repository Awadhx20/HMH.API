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
    internal class DoctorScheduleConfigrtions : IEntityTypeConfiguration<DoctorSchedule>
    {
        public void Configure(EntityTypeBuilder<DoctorSchedule> builder)
        {
            builder.HasKey(ds => ds.Id);

            
            builder.Property(ds => ds.DayOfWeek)
                   .IsRequired();

            
            builder.Property(ds => ds.StartTime)
                   .IsRequired();

            builder.Property(ds => ds.EndTime)
                   .IsRequired();

            
            builder.Property(ds => ds.MaxAppointmentsPerDay)
                   .IsRequired();

           
           

            builder.HasData(
                new DoctorSchedule
                {
                    Id=1,
                    DayOfWeek=1,
                    DoctorId=1,
                    StartTime=new TimeSpan(5,0,0),
                    EndTime=new TimeSpan (11,0,0),
                    MaxAppointmentsPerDay=50,
                    
                }
                );
        }
    }
}
