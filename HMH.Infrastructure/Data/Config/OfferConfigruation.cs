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
    public class OfferConfigruation : IEntityTypeConfiguration<Offer>
    {
        public void Configure(EntityTypeBuilder<Offer> builder)
        {
            builder.HasKey(o => o.Id);

            
            builder.Property(o => o.Title)
                   .IsRequired()
                   .HasMaxLength(100);

            
            builder.Property(o => o.Content)
                   .IsRequired()
                   .HasMaxLength(500);

            
            builder.Property(o => o.Discount)
                   .IsRequired();

           
            builder.Property(o => o.BookingUrl)
                   .IsRequired();

            builder.Property(o => o.CreatedAt)
                   .IsRequired();
        }
    }
}
